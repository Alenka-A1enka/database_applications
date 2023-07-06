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
    public partial class ClientPay : Form
    {
        public ClientPay()
        {
            InitializeComponent();
        }

        private void ClientPay_Load(object sender, EventArgs e)
        {
            string client_login = Client.login;

            List<string> client_id = SQLRequests.SelectRequest(
               "select id_клиент from Профиль where логин = @login",
               new string[] { "login" }, new string[] { client_login });

            List<string> number = SQLRequests.SelectRequest(
     "select Номер_договора from Договор where id_клиент = @id",
     new string[] { "id" }, new string[] { client_id[0] });

            List<string> sum = SQLRequests.SelectRequest(
     "select сумма_страхового_случая from Договор where id_клиент = @id",
     new string[] { "id" }, new string[] { client_id[0] });


            for (int i = 0; i < number.Count; i++)
            {
                List<string> dates = SQLRequests.SelectRequest(
         "select дата_выплаты from Страховой_случай where id_договор = @numb and дата_выплаты is not null",
         new string[] { "numb" }, new string[] { number[i] });
                if(dates.Count != 0)
                {
                    if(label2.Text != "У вас не было страховых случаев")
                    {
                        label2.Text += "Номер договора: " + number[i] + "\nСумма: " + sum[i] +
                            "\nДата выплаты: " + dates[i].Substring(0, 10) + "\n\n";
                    }
                    else
                    {
                        label2.Text = "Номер договора: " + number[i] + "\nСумма: " + sum[i] +
                            "\nДата выплаты: " + dates[i].Substring(0, 10) + "\n\n";
                    }
                }
            }


        }
    }
}
