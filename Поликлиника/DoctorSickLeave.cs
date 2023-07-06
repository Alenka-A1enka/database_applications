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
    public partial class DoctorSickLeave : Form
    {
        public DoctorSickLeave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            List<string> ident_doctor = SQLRequests.SelectRequest(
                          "select ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА from ПОЛЬЗОВАТЕЛИ where ЛОГИН = @login",
                          new string[] { "login" }, new string[] { Doctor.login });
            id_doc = ident_doctor[0];

            List<string> id_pacient = SQLRequests.SelectRequest(
                          "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @n1 and имя = @name",
                          new string[] { "n1", "name" }, new string[] { textBox1.Text, textBox2.Text });
            id_pac = id_pacient[0];

            if (id_pacient.Count == 0)
            {
                MessageBox.Show("Такого пациента нет в базе!");
                return;
            }

            //select * from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента = 6 and идентификатор_специалиста = 1 and дата_закрытия is null

            List<string> lists_open = SQLRequests.SelectRequest(
                          "select дата_открытия from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента = @pac and идентификатор_специалиста = @doc and дата_закрытия is null",
                          new string[] { "pac", "doc" }, new string[] { id_pacient[0], ident_doctor[0] });
           
            List<string> lists_diagnoz = SQLRequests.SelectRequest(
                          "select диагноз from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента = @pac and идентификатор_специалиста = @doc and дата_закрытия is null",
                          new string[] { "pac", "doc" }, new string[] { id_pacient[0], ident_doctor[0] });

            List<string> lists_number = SQLRequests.SelectRequest(
                        "select НОМЕР_БОЛЬНИЧНОГО_ЛИСТА from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента = @pac and идентификатор_специалиста = @doc and дата_закрытия is null",
                        new string[] { "pac", "doc" }, new string[] { id_pacient[0], ident_doctor[0] });
            label5.Text = "";
            try
            {
                number = lists_number[0];
            
            label5.Text += "Дата открытия больничного листа: " + lists_open[0].Substring(0, 10);
            label5.Text += "\n\nДиагноз пациента: " + lists_diagnoz[0];
            }
            catch { }


        }
        string number = "";
        string id_pac = "";
        string id_doc = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if(number != "")
            {
                DateTime dt = DateTime.Now;
                List<string> update_table = SQLRequests.SelectRequest(
                       "update БОЛЬНИЧНЫЕ_ЛИСТЫ set дата_закрытия = @date where идентификатор_пациента = @pac and идентификатор_специалиста = @doc and дата_закрытия is null",
                       new string[] { "date","pac", "doc" }, new string[] {dt.ToString(), id_pac, id_doc });
                MessageBox.Show("Больничный закрыт");
            }
            else
            {
                MessageBox.Show("У пациента нет открытых больничных листов!");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            DateTime dt = DateTime.Now;
            List<string> id_pacient = SQLRequests.SelectRequest(
                          "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @n1 and имя = @name",
                          new string[] { "n1", "name" }, new string[] { textBox3.Text, textBox4.Text });
            List<string> ident_doctor = SQLRequests.SelectRequest(
                         "select ИДЕНТИФИКАТОР_СПЕЦИАЛИСТА from ПОЛЬЗОВАТЕЛИ where ЛОГИН = @login",
                         new string[] { "login" }, new string[] { Doctor.login });
            if (id_pacient.Count == 0)
            {
                MessageBox.Show("Такого пациента нет в базе!");
                return;
            }

            List<string> lists_open = SQLRequests.SelectRequest(
                          "select дата_открытия from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента = @pac and идентификатор_специалиста = @doc and дата_закрытия is null",
                          new string[] { "pac", "doc" }, new string[] { id_pacient[0], ident_doctor[0] });

            if(lists_open.Count != 0)
            {
                MessageBox.Show("Больничный уже открыт");
                return;
            }

            List<string> insert_table = SQLRequests.SelectRequest(
                          "insert into БОЛЬНИЧНЫЕ_ЛИСТЫ(дата_открытия, идентификатор_пациента, идентификатор_специалиста, диагноз) values(@date, @pac, @doc, @d)",
                          new string[] { "date", "pac", "doc", "d" }, new string[] { dt.ToString(), id_pacient[0], ident_doctor[0], textBox5.Text });
            MessageBox.Show("Больничный лист открыт");

        }

        private void DoctorSickLeave_Load(object sender, EventArgs e)
        {

        }
    }
}
