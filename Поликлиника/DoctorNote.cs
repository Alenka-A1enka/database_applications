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
    public partial class DoctorNote : Form
    {
        public DoctorNote()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!");
                return;
            }

            //ищем идентификатор пациента

            List<string> id_pacient = SQLRequests.SelectRequest(
                           "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @n1 and имя = @name",
                           new string[] { "n1", "name" }, new string[] { textBox1.Text, textBox2.Text });
            if (id_pacient.Count == 0)
            {
                MessageBox.Show("Такого пациента нет в базе!");
                return;
            }

            List<string> insert_into_table = SQLRequests.SelectRequest(
                           "insert into ЗАПИСЬ_К_СПЕЦИАЛИСТАМ(дата, время_начала_приема, идентификатор_специалиста, идентификатор_пациента) values(@date, @time, @doc, @pac)",
                           new string[] { "date", "time", "doc", "pac" }, new string[] { comboBox3.Text, comboBox4.Text, ident, id_pacient[0] });

            MessageBox.Show("Запись сделана!");
        }
        DateTime[] dateTimes;

        private void DoctorNote_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
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
        }
        string ident = "";
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

            //получаем из логина идентификатор
            List<string> ident_doctor = SQLRequests.SelectRequest(
                          "select ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА from ПОЛЬЗОВАТЕЛИ where ЛОГИН = @login",
                          new string[] { "login" }, new string[] { Doctor.login });
            ident = ident_doctor[0];

            //расписание врача на этот день
            List<string> schedule_start = SQLRequests.SelectRequest(
               "select время_начала_приема from РАСПИСАНИЕ_СПЕЦИАЛИСТОВ where ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА = @id and ДЕНЬ_НЕДЕЛИ = @day",
               new string[] { "id", "day" }, new string[] { ident_doctor[0], current_dayOfWeek });
            List<string> schedule_end = SQLRequests.SelectRequest(
               "select время_окончания_приема from РАСПИСАНИЕ_СПЕЦИАЛИСТОВ where ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА = @id and ДЕНЬ_НЕДЕЛИ = @day",
               new string[] { "id", "day" }, new string[] { ident_doctor[0], current_dayOfWeek });

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
                free_time.Add(i + ":30");
            }

            //смотрит время, которое уже занято
            List<string> notFree_time = SQLRequests.SelectRequest(
                   "select время_начала_приема from ЗАПИСЬ_К_СПЕЦИАЛИСТАМ where дата = @date and идентификатор_специалиста = @id",
                   new string[] { "date", "id" }, new string[] { dt.ToString(), ident_doctor[0] });

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
    }
}
