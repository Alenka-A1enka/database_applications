using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Страховая
{
    public partial class InsuranceCase : Form
    {
        public InsuranceCase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (number.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Заполните все необходимые поля");
                return;
            }


            List<string> status_dogovor = SQLRequests.SelectRequest(
               "select Статус from Договор where Номер_договора = @n",
               new string[] { "n" }, new string[] { number.Text });
            if (status_dogovor.Count == 0)
            {
                MessageBox.Show("Такого договора нет");
                return;
            }
            if (status_dogovor[0] == "закрыт")
            {
                MessageBox.Show("Договор уже закрыт");
                return;
            }

            List<string> okonch = SQLRequests.SelectRequest(
               "select дата_окончания from Договор where Номер_договора = @n",
               new string[] { "n" }, new string[] { number.Text });
            DateTime dt = Convert.ToDateTime(okonch[0]);
            DateTime dt_now = DateTime.Now;
            if (dt < dt_now)
            {
                MessageBox.Show("Договор уже недействителен");
                return;
            }

            //такая заявка уже оформлена ранее

            List<string> id_z = SQLRequests.SelectRequest(
               "select Номер from Страховой_случай where id_договор = @n and дата_выплаты is not null",
               new string[] { "n" }, new string[] { number.Text });

            if (id_z.Count != 0)
            {
                MessageBox.Show("Страховой случай по договору уже есть");
                return;
            }

            //такая заявка есть в заявках и надо просмотреть список заявок

            List<string> id_z2 = SQLRequests.SelectRequest(
               "select Номер from Страховой_случай where id_договор = @n and дата_выплаты is null",
               new string[] { "n" }, new string[] { number.Text });

            if (id_z2.Count != 0)
            {
                MessageBox.Show("Заявка уже оставлена, посмотрите список заявок во вкладке");
                return;
            }



            //закрыть договор в конце

            List<string> update_dogovor = SQLRequests.SelectRequest(
                         "update Договор set статус = 'закрыт' where Номер_договора = @n",
                         new string[] { "n" }, new string[] { number.Text });


            List<string> insert_case = SQLRequests.SelectRequest(
             "insert into Страховой_случай (id_договор, дата_выплаты, пояснение) " +
             "values (@id, @date, @po)",
             new string[] { "id", "date", "po" }, 
             new string[] { number.Text, dt_now.ToString(), richTextBox1.Text });

            MessageBox.Show("Страховой случай добавлен");
            return;
        }

        private void просмотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AllRequest();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void InsuranceCase_Load(object sender, EventArgs e)
        {

        }
    }
}
