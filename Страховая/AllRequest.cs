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
    public partial class AllRequest : Form
    {
        public AllRequest()
        {
            InitializeComponent();
        }
        List<string> ids_dogovor;

        List<string> req_about;
        private void AllRequest_Load(object sender, EventArgs e)
        {
            
            ids_dogovor = SQLRequests.SelectRequest(
                         "select id_договор from Страховой_случай where дата_выплаты is null",
                         new string[] { }, new string[] { });

            req_about = SQLRequests.SelectRequest(
                        "select пояснение from Страховой_случай where дата_выплаты is null",
                        new string[] { }, new string[] { });

            Label[] numbers = new Label[] { num1, num2, num3, num4, num5 };
            Label[] abouts = new Label[] { about1, about2, about3, about4, about5 };
            Button[] buttons = new Button[] { b1, b2, b3, b4, b5 };


            try
            {
                for (int i = 0; i < ids_dogovor.Count; i++)
                {
                    numbers[i].Visible = true;
                    buttons[i].Visible = true;
                    numbers[i].Text += ": " + ids_dogovor[i];
                }
                for (int i = 0; i < req_about.Count; i++)
                {
                    abouts[i].Visible = true;
                    abouts[i].Text = "Описание заявки: " + req_about[i];
                }
            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new AnswerRequest(ids_dogovor[0], req_about[0]);
            f.Show();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            var f = new AnswerRequest(ids_dogovor[1], req_about[1]);
            f.Show();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            var f = new AnswerRequest(ids_dogovor[2], req_about[2]);
            f.Show();
        }

        private void b4_Click(object sender, EventArgs e)
        {
            var f = new AnswerRequest(ids_dogovor[3], req_about[3]);
            f.Show();
        }

        private void b5_Click(object sender, EventArgs e)
        {
            var f = new AnswerRequest(ids_dogovor[4], req_about[4]);
            f.Show();
        }
    }
}
