using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Рекламное_агентство
{
    public partial class AgentMainPage : Form
    {
        public AgentMainPage()
        {
            InitializeComponent();
        }

        private void новыеЗаявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AllNewRequests();
            f.Show();
        }

        private void заявкиНаВыполненииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AllRequests("на выполнении");
            f.Show();
        }

        private void завершенныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AllRequests("завершенные");
            f.Show();
        }

        private void отклоненныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AllRequests("отклоненные");
            f.Show();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Statistics();
            f.Show();
        }

        private void AgentMainPage_Load(object sender, EventArgs e)
        {

            List<string> surname = SQLRequests.SelectRequest(
               "select фамилия from Клиент",
               new string[] { }, new string[] {  });

            List<string> name = SQLRequests.SelectRequest(
               "select имя from Клиент",
               new string[] { }, new string[] { });

            List<string> otch = SQLRequests.SelectRequest(
               "select отчество from Клиент",
               new string[] { }, new string[] { });

            List<string> date = SQLRequests.SelectRequest(
               "select [дата рождения] from Клиент",
               new string[] { }, new string[] { });

            List<string> address = SQLRequests.SelectRequest(
               "select адрес from Клиент",
               new string[] { }, new string[] { });

            if (surname.Count != 0) label2.Text = "";
            for (int i = 0; i < surname.Count; i++)
            {
                label2.Text += surname[i] + " " + name[i] + " " + otch[i] + "\n" +
                    "Дата рождения:  " + date[i].Substring(0, 11) + "\nАдрес: " + address[i] + "\n\n";
            }

        }
    }
}
