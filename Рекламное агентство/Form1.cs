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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var f = new Register();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (textBox1.Text == "agent" && textBox2.Text == "123")
            {
                AgentMainPage f = new AgentMainPage();
                this.Hide();
                f.ShowDialog();
                this.Show();
                return;
            }

            //запрос пароля

            List<string> pass = SQLRequests.SelectRequest(
               "select пароль from Профиль where логин = @login",
               new string[] { "login" }, new string[] { textBox1.Text });


            if (pass.Count == 0)
            {
                MessageBox.Show("Неверный логин!");
                return;
            }

            if(pass[0] == textBox2.Text)
            {
                Client.login = textBox1.Text;
                List<string> id_client = SQLRequests.SelectRequest(
                   "select id_клиента from Профиль where логин = @login",
                   new string[] { "login" }, new string[] { textBox1.Text });
                Client.id = id_client[0];

                var f2 = new ClientMainPage();
                this.Hide();
                f2.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
