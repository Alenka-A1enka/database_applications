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
    public partial class ClientMainPage : Form
    {
        public ClientMainPage()
        {
            InitializeComponent();
        }

        private void моиЗаявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ClientMainPage_Load(object sender, EventArgs e)
        {

            List<string> date1 = SQLRequests.SelectRequest(
               "select дата_формирования from Заявка where владелец = @id",
               new string[] { "id" }, new string[] { Client.id });

            List<string> status = SQLRequests.SelectRequest(
               "select статус from Заявка where владелец = @id",
               new string[] { "id" }, new string[] { Client.id });

            List<string> date2 = SQLRequests.SelectRequest(
               "select дата_изменения_статуса from Заявка where владелец = @id",
               new string[] { "id" }, new string[] { Client.id });

            List<string> id_opisaine = SQLRequests.SelectRequest(
               "select id_описание from Заявка where владелец = @id",
               new string[] { "id" }, new string[] { Client.id });

            List<string> budzet = new List<string>();
            List<string> type = new List<string>();

            for (int i = 0; i < id_opisaine.Count; i++)
            {
                List<string> b = SQLRequests.SelectRequest(
                   "select бюджет from описание_заявки where id = @id",
                   new string[] { "id" }, new string[] { id_opisaine[i] });
                budzet.Add(b[0]);

                List<string> t = SQLRequests.SelectRequest(
                   "select тип_рекламы from описание_заявки where id = @id",
                   new string[] { "id" }, new string[] { id_opisaine[i] });
                type.Add(t[0]);
            }
            if (date2.Count != 0) label1.Text = "";
            for (int i = 0; i < date1.Count; i++)
            {
                label1.Text += "\nДата формирования: " + date1[i].Substring(0, 11) +
                    "\nБюджет: " + budzet[i] + "\nТип рекламы: " + type[i] +
                    "\nСтатус заявки: " + status[i] + "\nДата последнего изменения статуса: " +
                    date2[i].Substring(0, 11);
                label1.Text += "\n\n";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            var f = new AddRequest();
            f.Show();


        }
    }
}
