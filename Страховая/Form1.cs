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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                var f = new AdminMainPage();
                this.Hide();
                f.ShowDialog();
                this.Show();
                return;
            }

            //запрос пароля


            List<string> pass = SQLRequests.SelectRequest(
               "select пароль from Профиль where логин = @login",
               new string[] { "login" }, new string[] { textBox1.Text });


            if(pass.Count == 0)
            {
                MessageBox.Show("Неверный логин!");
                return;
            }

            //сверка пароля
            //если пароль неверный
            if(pass[0] != textBox2.Text)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            //проверка роли

            List<string> role = SQLRequests.SelectRequest(
               "select роль from Профиль where логин = @login",
               new string[] { "login" }, new string[] { textBox1.Text });
            

            
            if(role[0] == "клиент")
            {
                Client.login = textBox1.Text;

                var f = new ClientMainPage();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if(role[0] == "агент")
            {
                Agent.login = textBox1.Text;

                //получение id
                List<string> id = SQLRequests.SelectRequest(
                   "select id_агент from Профиль where логин = @login",
                   new string[] { "login" }, new string[] { textBox1.Text });
                Agent.id = id[0];

                var f = new AgentMainPage();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
