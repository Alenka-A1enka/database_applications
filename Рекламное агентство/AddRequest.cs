using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Рекламное_агентство
{
    public partial class AddRequest : Form
    {
        public AddRequest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //владелец, дата_формирования, статус, дата_изменения_статуса, описание
            //тип_рекламы, бюджет

            if (budzet.Text == "" || comboBox1.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (richTextBox1.Text.Length > 100)
            {
                MessageBox.Show("Описание не может быть больше 100 символов");
                return;
            }
            try
            {
                int cost = Convert.ToInt32(budzet.Text);
            }
            catch { MessageBox.Show("Неверный формат данных (поле бюджет)"); return; }
            if (Convert.ToInt32(budzet.Text) < 5000)
            {
                MessageBox.Show("Бюджет не может быть меньше 5000");
                return;
            }

            List<string> insert_opisanie = SQLRequests.SelectRequest(
               "insert into описание_заявки (тип_рекламы, бюджет) values(@type, @b)",
               new string[] { "type", "b" }, new string[] { comboBox1.Text, budzet.Text });

            List<string> max_id = SQLRequests.SelectRequest(
               "select max(id) from описание_заявки",
               new string[] { }, new string[] { });

            DateTime dt = DateTime.Now;

            List<string> insert_reques = SQLRequests.SelectRequest(
               "insert into Заявка (владелец, дата_формирования, статус, описание, id_описание, дата_изменения_статуса) " +
               "values(@v, @d1, @s, @o, @id, @d2)",
               new string[] { "v", "d1", "s", "o", "id", "d2" },
               new string[] { Client.id, dt.ToString(), "новые", richTextBox1.Text, max_id[0], dt.ToString() });

            MessageBox.Show("Заявка добавлена! Дождитесь формирования накладной");


            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.TypeText("Форма №НК" + max_id[0]);
            wordApp.Selection.TypeText("\nУтвеждена от " + dt.ToString().Substring(0, 10));



            List<string> s1 = SQLRequests.SelectRequest(
           "select фамилия from Клиент where id = 5",
           new string[] { }, new string[] { });
            List<string> s2 = SQLRequests.SelectRequest(
           "select имя from Клиент where id = 5",
           new string[] { }, new string[] { });
            List<string> s3 = SQLRequests.SelectRequest(
           "select отчество from Клиент where id = 5",
           new string[] { }, new string[] { });


            List<string> data1 = SQLRequests.SelectRequest(
           "select [дата рождения] from Клиент where id = 5",
           new string[] { }, new string[] { });
            List<string> data2 = SQLRequests.SelectRequest(
           "select адрес from Клиент where id = 5",
           new string[] { }, new string[] { });
            List<string> data3 = SQLRequests.SelectRequest(
           "select серия_паспорта from Клиент where id = 5",
           new string[] { }, new string[] { });
            List<string> data4 = SQLRequests.SelectRequest(
           "select номер_паспорта from Клиент where id = 5",
           new string[] { }, new string[] { });



            wordApp.Selection.TypeText("\n\n\nФИО клиента: " + s1[0] + " " + s2[0] + " " + s3[0]);
            wordApp.Selection.TypeText("\nДата рождения клиента: " + data1[0].Substring(0, 10));
            wordApp.Selection.TypeText("\nАдрес: " + data2[0]);
            wordApp.Selection.TypeText("\nСерия и номер паспорта: " + data3[0] + " " + data4[0]);

            wordApp.Selection.TypeText("\n\nБюджет рекламы: " + budzet.Text);
            wordApp.Selection.TypeText("\nТип рекламы: " + comboBox1.Text);
            wordApp.Selection.TypeText("\nОписание: " + richTextBox1.Text);




            this.Close();

        }
    }
}
