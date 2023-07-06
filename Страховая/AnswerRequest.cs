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
    public partial class AnswerRequest : Form
    {
        string id_dogovor;
        string opisanie;
        public AnswerRequest(string id_dogovor, string opisanie)
        {
            InitializeComponent();

            this.id_dogovor = id_dogovor;
            this.opisanie = opisanie;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text == "")
            {
                MessageBox.Show("Уточните описание к заявке");
                return;
            }

            DateTime dt = DateTime.Now;

            List<string> update = SQLRequests.SelectRequest(
                    "update Страховой_случай set дата_выплаты = @date where id_договор = @n",
                    new string[] { "date", "n" }, new string[] { dt.ToString(), id_dogovor.ToString() });


            //закрытие договора
            List<string> update_dogovor = SQLRequests.SelectRequest(
                        "update Договор set статус = 'закрыт' where Номер_договора = @n",
                        new string[] { "n" }, new string[] { id_dogovor.ToString() });


            MessageBox.Show("Страховой случай оформлен");
            this.Close();

        }

        private void AnswerRequest_Load(object sender, EventArgs e)
        {
            number.Text = id_dogovor.ToString();
            about.Text = opisanie;

        }
    }
}
