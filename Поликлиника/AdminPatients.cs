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
    public partial class AdminPatients : Form
    {
        public AdminPatients()
        {
            InitializeComponent();
        }

        private void AdminPatients_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //получаем идентификатор пациента по фамилии

            List<string> id = SQLRequests.SelectRequest(
               "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @name",
               new string[] { "name" }, new string[] { lastname.Text });

            if(id.Count == 0)
            {
                MessageBox.Show("Такого пациента нет!");
                return;
            }

            //находим результаты анализов за последний месяц
            
            DateTime datetime = DateTime.Now;
            datetime = datetime.AddMonths(-1);

            List<string> results = SQLRequests.SelectRequest(
               "select основные_результаты from ЗАПИСЬ_ИССЛЕДОВАНИЯ where идентификатор_пациента = @id and дата > @time and основные_результаты is not null",
               new string[] { "id", "time" }, new string[] { id[0], datetime.ToString().Substring(0, 10)});

            List<string> results_dates = SQLRequests.SelectRequest(
               "select дата from ЗАПИСЬ_ИССЛЕДОВАНИЯ where идентификатор_пациента = @id and дата > @time and основные_результаты is not null",
               new string[] { "id", "time" }, new string[] { id[0], datetime.ToString().Substring(0, 10) });

            int location = 200;
            for (int i = 0; i < results.Count; i++)
            {
                //72; 524

                Label label = new Label();
                label.AutoSize = true;
                //Microsoft Sans Serif; 10,8pt
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                label.ForeColor = System.Drawing.Color.White;
                label.Location = new System.Drawing.Point(45, location);
                label.Text = results[i] + " (" + results_dates[i].Substring(0, 10) + ")";

                location += 45;
                this.tabPage1.Controls.Add(label);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(last_name.Text == "" || name.Text == "" || middle_name.Text == "" ||
                address.Text == "" || pas1.Text == "" || pas2.Text == "" || pol.Text == "" || birthday.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!");
                return;
            }
            if(pas1.Text.Length != 4 || pas2.Text.Length != 6)
            {
                MessageBox.Show("Паспортные данные заполнены неверно!");
                return;
            }
            try
            {
                int k = Convert.ToInt32(pas1.Text);
                k = Convert.ToInt32(pas2.Text);
            }
            catch
            {
                MessageBox.Show("Паспортные данные заполнены неверно!");
                return;
            }
            if(pol.Text.Length > 16)
            {
                MessageBox.Show("Номер страхового полиса не может быть длиннее 16 символов!");
                return;
            }

            //добавление нового пациента

            List<string> add_pacient = SQLRequests.SelectRequest(
                          "insert into ПАЦИЕНТ (фамилия, имя,отчество, серия_паспорта, номер_паспорта, страховой_полис, адрес, дата_рождения) values(@lastn, @name, @middlen, @number, @seria, @polis, @address, @birthday)",
                          new string[] { "lastn", "name", "middlen", "number", "seria", "polis", "address", "birthday" }, new string[] { last_name.Text, name.Text, middle_name.Text, pas1.Text, pas2.Text, pol.Text, address.Text, birthday.Text });



            //уведомление
            MessageBox.Show("Амбулаторная карта нового пациента добавлена!");
            this.Close();

        }
    }
}
