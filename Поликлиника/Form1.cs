using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Поликлиника
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }

            //поиск пароля по логину в БД 
            List<string> password = SQLRequests.SelectRequest(
               "select пароль from ПОЛЬЗОВАТЕЛИ where ЛОГИН = @login",
               new string[] { "login" }, new string[] { login.Text });
            if(password.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }

            //сверка пароля заданному
            if (pass.Text != password[0])
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }

            //если верный
            //получение роли по логину

            List<string> role = SQLRequests.SelectRequest(
               "select роль from ПОЛЬЗОВАТЕЛИ where ЛОГИН = @login",
               new string[] { "login" }, new string[] { login.Text });


            //если пользователь - администратор
            if (role[0] == "администратор")
            {
                var f = new AdminPage1();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }

            //если пользователь - врач
            else if (role[0] == "врач")
            {
                Doctor.login = login.Text;
                var f = new DoctorPage1();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }

            //если неверный - сообщение об ошибке - возврат
            else
            {
                MessageBox.Show("Непредвиденная ошибка!");
                return;
            }
        }
    }
}
