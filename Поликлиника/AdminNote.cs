using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Поликлиника
{
    public partial class AdminNote : Form
    {
        public AdminNote()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.Items.Clear();


            List<string> doctor_surname = SQLRequests.SelectRequest(
               "select фамилия from СПЕЦИАЛИСТЫ where специализация = @spez",
               new string[] { "spez" }, new string[] { comboBox1.Text });

            List<string> doctor_name = SQLRequests.SelectRequest(
               "select имя from СПЕЦИАЛИСТЫ where специализация = @spez",
               new string[] { "spez" }, new string[] { comboBox1.Text });

            string[] full_names = new string[doctor_name.Count];
            for (int i = 0; i < full_names.Length; i++)
            {
                full_names[i] = doctor_surname[i] + " " + doctor_name[i];
            }
            comboBox2.Items.AddRange(full_names);


        }
        DateTime[] dateTimes;
        private void AdminNote_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox6.Items.Clear();
            dateTimes = new DateTime[7];
            dateTimes[0] = DateTime.Now;
            for (int i = 1; i < 7; i++)
            {
                dateTimes[i] = dateTimes[0].AddDays(i);
            }
            string[] dates = new string[7];
            for (int i = 0; i < dateTimes.Length; i++)
            {
                dates[i] = dateTimes[i].ToString().Substring(0, 10);
            }

            comboBox3.Items.AddRange(dates);
            comboBox6.Items.AddRange(dates);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox4.Items.Clear();

            //узнаем день недели на выбранную дату
            string current_dayOfWeek = "";
            int index_of_date = comboBox3.SelectedIndex;
            DateTime dt = dateTimes[index_of_date];
            if (dt.DayOfWeek == DayOfWeek.Monday) current_dayOfWeek = "Пн";
            if (dt.DayOfWeek == DayOfWeek.Tuesday) current_dayOfWeek = "Вт";
            if (dt.DayOfWeek == DayOfWeek.Wednesday) current_dayOfWeek = "Ср";
            if (dt.DayOfWeek == DayOfWeek.Thursday) current_dayOfWeek = "Чт";
            if (dt.DayOfWeek == DayOfWeek.Friday) current_dayOfWeek = "Пт";
            if (dt.DayOfWeek == DayOfWeek.Saturday) current_dayOfWeek = "Сб";
            if (dt.DayOfWeek == DayOfWeek.Sunday) current_dayOfWeek = "Вс";

            //расписание врача на этот день
            List<string> schedule_start = SQLRequests.SelectRequest(
               "select время_начала_приема from РАСПИСАНИЕ_СПЕЦИАЛИСТОВ where ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА = @id and ДЕНЬ_НЕДЕЛИ = @day",
               new string[] { "id", "day" }, new string[] { ident_doctor, current_dayOfWeek});
            List<string> schedule_end = SQLRequests.SelectRequest(
               "select время_окончания_приема from РАСПИСАНИЕ_СПЕЦИАЛИСТОВ where ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА = @id and ДЕНЬ_НЕДЕЛИ = @day",
               new string[] { "id", "day" }, new string[] { ident_doctor, current_dayOfWeek });

            List<string> free_time = new List<string>();
            int start = 0;
            try
            {
                start = Convert.ToInt32(schedule_start[0].Substring(0, 2));
            } catch { start = Convert.ToInt32(schedule_start[0].Substring(0, 1)); }
            int end = Convert.ToInt32(schedule_end[0].Substring(0, 2));

            for (int i = start; i < end; i++)
            {
                free_time.Add(i + ":00");
                free_time.Add(i + ":30");
            }

            //смотрит время, которое уже занято
            List<string> notFree_time = SQLRequests.SelectRequest(
                   "select время_начала_приема from ЗАПИСЬ_К_СПЕЦИАЛИСТАМ where дата = @date and идентификатор_специалиста = @id",
                   new string[] { "date", "id" }, new string[] { dt.ToString(), ident_doctor });

            for (int i = 0; i < notFree_time.Count; i++)
            {
                notFree_time[i] = notFree_time[i].Substring(0, 5);
                for (int j = 0; j < free_time.Count; j++)
                {
                    if (free_time[j] == notFree_time[i]) free_time.RemoveAt(j);
                }
            }

            string[] free_times = new string[free_time.Count];
            for (int i = 0; i < free_time.Count; i++)
            {
                free_times[i] = free_time[i];
            }

            comboBox4.Items.AddRange(free_times);

        }
        string ident_doctor = "";
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = comboBox2.Text;
            string[] names = str.Split(new char[] { ' ' });
            

            List<string> doctor_surname = SQLRequests.SelectRequest(
               "select ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА from СПЕЦИАЛИСТЫ where фамилия = @l and имя = @n",
               new string[] { "l", "n" }, new string[] { names[0], names[1] });

            ident_doctor = doctor_surname[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || 
                comboBox2.Text == "" || comboBox3.Text ==  "" || comboBox4.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!");
                return;
            }

            //ищем идентификатор пациента

            List<string> id_pacient = SQLRequests.SelectRequest(
                           "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @n1 and имя = @name",
                           new string[] { "n1", "name" }, new string[] { textBox1.Text, textBox2.Text });
            if(id_pacient.Count == 0)
            {
                MessageBox.Show("Такого пациента нет в базе!");
                return;
            }

            List<string> insert_into_table = SQLRequests.SelectRequest(
                           "insert into ЗАПИСЬ_К_СПЕЦИАЛИСТАМ(дата, время_начала_приема, идентификатор_специалиста, идентификатор_пациента) values(@date, @time, @doc, @pac)",
                           new string[] { "date", "time", "doc", "pac"}, new string[] { comboBox3.Text, comboBox4.Text, ident_doctor, id_pacient[0] });

            MessageBox.Show("Запись сделана!");
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Enabled = true;
            comboBox7.Items.Clear();

            //узнаем день недели на выбранную дату
            string current_dayOfWeek = "";
            int index_of_date = comboBox6.SelectedIndex;
            DateTime dt = dateTimes[index_of_date];
            if (dt.DayOfWeek == DayOfWeek.Monday) current_dayOfWeek = "Пн";
            if (dt.DayOfWeek == DayOfWeek.Tuesday) current_dayOfWeek = "Вт";
            if (dt.DayOfWeek == DayOfWeek.Wednesday) current_dayOfWeek = "Ср";
            if (dt.DayOfWeek == DayOfWeek.Thursday) current_dayOfWeek = "Чт";
            if (dt.DayOfWeek == DayOfWeek.Friday) current_dayOfWeek = "Пт";
            if (dt.DayOfWeek == DayOfWeek.Saturday) current_dayOfWeek = "Сб";
            if (dt.DayOfWeek == DayOfWeek.Sunday) current_dayOfWeek = "Вс";



            //расписание лаборатории на этот день

            List<string> schedule_start = SQLRequests.SelectRequest(
               "select время_начала_исследования from РАСПИСАНИЕ_ЛАБОРАТОРИИ where НАИМЕНОВАНИЕ_ИССЛЕДОВАНИЯ = @id and ДЕНЬ_НЕДЕЛИ = @day",
               new string[] { "id", "day" }, new string[] { comboBox5.Text, current_dayOfWeek });
            List<string> schedule_end = SQLRequests.SelectRequest(
               "select время_окончания_исследования from РАСПИСАНИЕ_ЛАБОРАТОРИИ where НАИМЕНОВАНИЕ_ИССЛЕДОВАНИЯ = @id and ДЕНЬ_НЕДЕЛИ = @day",
               new string[] { "id", "day" }, new string[] { comboBox5.Text, current_dayOfWeek });
            
            List<string> free_time = new List<string>();
            int start = 0;
            try
            {
                start = Convert.ToInt32(schedule_start[0].Substring(0, 2));
            }
            catch { start = Convert.ToInt32(schedule_start[0].Substring(0, 1)); }
            int end = Convert.ToInt32(schedule_end[0].Substring(0, 2));

            for (int i = start; i < end; i++)
            {
                free_time.Add(i + ":00");
                free_time.Add(i + ":20");
                free_time.Add(i + ":40");
            }

            //смотрит время, которое уже занято
            List<string> notFree_time = SQLRequests.SelectRequest(
                   "select время from ЗАПИСЬ_ИССЛЕДОВАНИЯ where дата = @date and наименование_исследования = @id",
                   new string[] { "date", "id" }, new string[] { dt.ToString(), comboBox6.Text });

            for (int i = 0; i < notFree_time.Count; i++)
            {
                notFree_time[i] = notFree_time[i].Substring(0, 5);
                for (int j = 0; j < free_time.Count; j++)
                {
                    if (free_time[j] == notFree_time[i]) free_time.RemoveAt(j);
                }
            }

            string[] free_times = new string[free_time.Count];
            for (int i = 0; i < free_time.Count; i++)
            {
                free_times[i] = free_time[i];
            }

            comboBox7.Items.AddRange(free_times);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || comboBox5.Text == "" ||
               comboBox6.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!");
                return;
            }

            //ищем идентификатор пациента

            List<string> id_pacient = SQLRequests.SelectRequest(
                           "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @n1 and имя = @name",
                           new string[] { "n1", "name" }, new string[] { textBox3.Text, textBox4.Text });
            if (id_pacient.Count == 0)
            {
                MessageBox.Show("Такого пациента нет в базе!");
                return;
            }

            List<string> insert_into_table = SQLRequests.SelectRequest(
                           "insert into ЗАПИСЬ_ИССЛЕДОВАНИЯ(дата, время, наименование_исследования, идентификатор_пациента) values(@date, @time, @doc, @pac)",
                           new string[] { "date", "time", "doc", "pac" }, new string[] { comboBox6.Text, comboBox7.Text, comboBox5.Text, id_pacient[0] });

            MessageBox.Show("Запись сделана!");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
