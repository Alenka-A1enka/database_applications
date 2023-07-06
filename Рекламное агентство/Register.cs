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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(surname.Text == "" || name.Text == "" || otch.Text == "" || 
                dateb.Text == "" || address.Text == "" || seria.Text == "" || nomer.Text == "" ||
                login.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            List<string> login_count = SQLRequests.SelectRequest(
              "select логин from Профиль where логин = @l",
              new string[] { "l" }, new string[] { login.Text});
            if(login_count.Count != 0)
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }

           
            List<string> insert_client = SQLRequests.SelectRequest(
              "insert into Клиент(фамилия, имя, отчество, [дата рождения], адрес, серия_паспорта, номер_паспорта) " +
              "values(@s, @n, @o, @d, @a, @s2, @n2)",
              new string[] { "s", "n", "o", "d", "a", "s2", "n2" }, 
              new string[] { surname.Text, name.Text, otch.Text, dateb.Text, 
              address.Text, seria.Text, nomer.Text});

            List<string> id_client = SQLRequests.SelectRequest(
           "select id from Клиент where фамилия = @s and имя = @n",
           new string[] { "s", "n"}, new string[] { surname.Text, name.Text });

            DateTime dt = DateTime.Now;

            List<string> insert_profile = SQLRequests.SelectRequest(
         "insert into Профиль values (@l, @p, @id, @date)",
         new string[] { "l", "p", "id", "date" },
         new string[] { login.Text, pass.Text, id_client[0], dt.ToString() });

            MessageBox.Show("Профиль добавлен");
            this.Close();

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
