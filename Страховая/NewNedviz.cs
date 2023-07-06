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
    public partial class NewNedviz : Form
    {
        public NewNedviz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(city.Text == "" || street.Text == "" || home.Text == "" || kv.Text == "" ||
                surname.Text == "" || name.Text == "" || sum.Text == "" || razmer.Text == "")
            {
                MessageBox.Show("Заполните все необходимые поля");
                return;
            }


            List<string> insert_address = SQLRequests.SelectRequest(
               "insert into Адрес(город, улица, номер_дома, номер_кв) " +
               "values (@c, @s, @h, @k)",
               new string[] { "c", "s", "h", "k" }, 
               new string[] { city.Text, street.Text, home.Text, kv.Text });


           List<string> id_address = SQLRequests.SelectRequest(
               "select id from Адрес where город = @c and улица = @s and номер_дома = @h and номер_кв = @k",
               new string[] { "c", "s", "h", "k" },
               new string[] { city.Text, street.Text, home.Text, kv.Text });

            if(id_address.Count == 0)
            {
                MessageBox.Show("Ошибка при добавлении адреса");
                return;
            }

            List<string> id_client = SQLRequests.SelectRequest(
            "select id from Клиент where фамилия = @f and имя = @n",
            new string[] { "f", "n" }, new string[] { surname.Text, name.Text });

            if(id_client.Count == 0)
            {
                MessageBox.Show("Такого клиента нет в базе!");
                return;
            }

            List<string> insert_nedv = SQLRequests.SelectRequest(
            "insert into Недвижимость (id_адрес, id_клиент, стоимость, квадратура) " +
            "values (@ad, @cl, @sum, @kv) ",
            new string[] { "ad", "cl", "sum", "kv" }, 
            new string[] { id_address[0], id_client[0], sum.Text, razmer.Text});

            MessageBox.Show("Недвижимость добавлена");
            this.Close();
        }

        private void NewNedviz_Load(object sender, EventArgs e)
        {

        }
    }
}
