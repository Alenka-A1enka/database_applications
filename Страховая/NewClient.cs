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
    public partial class NewClient : Form
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (surname.Text == "" || name.Text == "" || otch.Text == "" ||
                dateb.Text == "" || nomer.Text == "" || seria.Text == "" ||
                snils.Text == "" || address.Text == "" || login.Text == "" || 
                pass.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            List<string> count_login = SQLRequests.SelectRequest(
               "select пароль from Профиль where логин = @l",
               new string[] { "l"}, new string[] { login.Text });

            if(count_login.Count != 0)
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }

            List<string> insert_client = SQLRequests.SelectRequest(
              "insert into Клиент(фамилия, имя, отчество, номер_паспорта, серия_паспорта, снилс, адрес, дата_рождения) " +
              "values(@f, @n, @o, @no, @s, @sn, @a, @d)",
              new string[] { "f", "n", "o", "no", "s", "sn", "a", "d" }, 
              new string[] { surname.Text, name.Text, otch.Text, nomer.Text, seria.Text, 
              snils.Text, address.Text, dateb.Text});

            List<string> id_client = SQLRequests.SelectRequest(
            "select id from Клиент where фамилия = @f and имя = @n",
            new string[] { "f", "n" }, new string[] { surname.Text, name.Text });

            if(id_client.Count == 0)
            {
                MessageBox.Show("Произошла ошибка");
                return;
            }


            List<string> insert_profile = SQLRequests.SelectRequest(
            "insert into Профиль (логин, пароль, id_агент, id_клиент, роль) " +
            "values (@l, @p, @a, @c, @r)",
            new string[] {"l", "p", "a", "c", "r" }, 
            new string[] { login.Text, pass.Text, Agent.id, id_client[0], "клиент" });

            MessageBox.Show("Клиент успешно добавлен в базу");
            this.Close();

        }

        private void NewClient_Load(object sender, EventArgs e)
        {

        }
    }
}
