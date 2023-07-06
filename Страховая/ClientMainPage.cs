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
    public partial class ClientMainPage : Form
    {
        public ClientMainPage()
        {
            InitializeComponent();
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ClientDogovor();
            f.Show();
        }

        private void выплатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ClientPay();
            f.Show();
        }

        private void ClientMainPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            try
            {
                int x = Convert.ToInt32(textBox1.Text);
            } catch { return; }

            
            List<string> current_dog = SQLRequests.SelectRequest(
                 "select * from Страховой_случай where id_договор = @id",
                 new string[] { "id" }, new string[] { textBox1.Text });

            if(current_dog.Count != 0)
            {
                MessageBox.Show("Страховой случай уже оформлен");
                return;
            }
            //договора такого нет

            List<string> insert = SQLRequests.SelectRequest(
                 "insert into Страховой_случай (id_договор, пояснение) values (@id, @ab)",
                 new string[] { "id", "ab" }, new string[] { textBox1.Text, richTextBox1.Text });

            MessageBox.Show("Заявка на страховую выплату оформлена");
            textBox1.Text = "";
            richTextBox1.Text = "";

        }
    }
}
