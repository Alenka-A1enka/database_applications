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
    public partial class ContractForm : Form
    {
        public ContractForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (surname.Text == "" || name.Text == "" || sum.Text == "" || comboBox1.Text == "" ||
                textBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if(id_home == "" && comboBox1.Text == "Страхование недвижимости")
            {
                MessageBox.Show("Уточните адрес недвижимости");
                return;
            }
            if(comboBox1.Text == "Страхование недвижимости" && textBox2.Text == "")
            {
                MessageBox.Show("Добавьте недвижимость");
                return;
            }

            DateTime dt = DateTime.Now;

            List<string> id_client = SQLRequests.SelectRequest(
               "select id from Клиент where фамилия = @s and имя = @n",
               new string[] { "s", "n" }, new string[] { surname.Text, name.Text });
            

            if (id_client.Count == 0)
            {
                MessageBox.Show("Такого клиента нет в базе");
                return;
            }
            idclient = id_client[0];

            List<string> insert_table = SQLRequests.SelectRequest(
          "insert into Договор (Статус, id_агент, id_клиент, дата_составления, дата_окончания, " +
          "сумма_страхового_случая, внесенная_сумма, id_вид) values " +
          "(@s1, @s2, @s3, @s4, @s5, @s6, @s7, @s8)",
          new string[] { "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8"}, new string[] 
          { "открыт", Agent.id, idclient, dt.ToString(), dt.AddYears(1).ToString(), sum.Text, textBox1.Text, comboBox1.Text});

            MessageBox.Show("Договор создан");
            surname.Text = "";
            name.Text = "";
            comboBox1.Text = "";
            sum.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        string id_home = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (sum.Text == "")
            {
                MessageBox.Show("Вы не внесли сумму страховых выплат");
                return;
            }
            double s = Convert.ToDouble(sum.Text);
            textBox1.Text = Math.Round(s / 10).ToString();

        }
        string idclient = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Вы не указали вид страхования");
                return;
            }
            if (comboBox1.Text == "Страхование жизни")
            {
                MessageBox.Show("Для данного вида страхования добавление недвижимости не предусмотрено");
                return;
            }
            if(surname.Text == "" || name.Text == "")
            {
                MessageBox.Show("Введите фамилию и имя клиента");
                return;
            }


            List<string> id_client = SQLRequests.SelectRequest(
               "select id from Клиент where фамилия = @s and имя = @n",
               new string[] { "s", "n" }, new string[] { surname.Text, name.Text });
            

            if(id_client.Count == 0)
            {
                MessageBox.Show("Такого клиента нет");
                return;
            }
            idclient = id_client[0];

            List<string> id_address = SQLRequests.SelectRequest(
               "select id_адрес from Недвижимость where id_клиент = @id",
               new string[] { "id" }, new string[] { id_client[0] });
            if (id_address.Count == 0)
            {
                MessageBox.Show("У клиента нет добавленной недвижимости");
                return;
            }

            var f = new GetHome(id_client[0]);
            f.Show();

            textBox2.Text = Home.address;
            id_home = Home.id;
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new NewClient();
            f.Show();
        }

        private void недвижимостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new NewNedviz();
            f.Show();
        }
    }
}
