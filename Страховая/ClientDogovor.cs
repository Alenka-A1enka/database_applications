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
    public partial class ClientDogovor : Form
    {
        public ClientDogovor()
        {
            InitializeComponent();

            this.AutoScroll = true;
        }

        private void ClientDogovor_Load(object sender, EventArgs e)
        {
            string client_login = Client.login;

            List<string> client_id = SQLRequests.SelectRequest(
               "select id_клиент from Профиль where логин = @login",
               new string[] { "login" }, new string[] { client_login });

            List<string> d1 = SQLRequests.SelectRequest(
               "select Номер_договора from Договор where id_клиент = @id",
               new string[] { "id" }, new string[] { client_id[0] });

            List<string> d2 = SQLRequests.SelectRequest(
               "select Статус from Договор where id_клиент = @id",
               new string[] { "id" }, new string[] { client_id[0] });

            List<string> d3 = SQLRequests.SelectRequest(
               "select дата_составления from Договор where id_клиент = @id",
               new string[] { "id" }, new string[] { client_id[0] });

            List<string> d4 = SQLRequests.SelectRequest(
               "select сумма_страхового_случая from Договор where id_клиент = @id",
               new string[] { "id" }, new string[] { client_id[0] });

            List<string> d5 = SQLRequests.SelectRequest(
               "select id_вид from Договор where id_клиент = @id",
               new string[] { "id" }, new string[] { client_id[0] });

            if(d1.Count == 0)
            {
                return;
            }

            label2.Text = "";

            for (int i = 0; i < d1.Count; i++)
            {
                label2.Text += "Номер договора: " + d1[i] + "\nСтатус: " + d2[i] +
                    "\nДата составления: " + d3[i] + "\nСумма страхового случая: " +
                    d4[i] + "\nВид страхования: " + d5[i] + "\n\n";
            }
        }
    }
}
