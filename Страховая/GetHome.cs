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
    public partial class GetHome : Form
    {
        string id_client;
        public GetHome(string id_client)
        {
            InitializeComponent();

            this.id_client = id_client;
        }

        private void GetHome_Load(object sender, EventArgs e)
        {
            List<string> id_address = SQLRequests.SelectRequest(
               "select id_адрес from Недвижимость where id_клиент = @id",
               new string[] { "id" }, new string[] { id_client });

            

            Home.id = id_address[0];

            List<string> city = SQLRequests.SelectRequest(
               "select город from Адрес where id = @id",
               new string[] { "id" }, new string[] { id_address[0] });

            List<string> street = SQLRequests.SelectRequest(
               "select улица from Адрес where id = @id",
               new string[] { "id" }, new string[] { id_address[0] });

            List<string> home = SQLRequests.SelectRequest(
               "select номер_дома from Адрес where id = @id",
               new string[] { "id" }, new string[] { id_address[0] });

            List<string> kv = SQLRequests.SelectRequest(
               "select номер_кв from Адрес where id = @id",
               new string[] { "id" }, new string[] { id_address[0] });


            label3.Text = "г. " + city[0] + " , ул. " + street[0] + " , " + home[0] +
                    " , кв. " + kv[0];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home.address = label3.Text;
            this.Close();
        }
    }
}
