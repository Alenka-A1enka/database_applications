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
    public partial class AllNewRequests : Form
    {
        public AllNewRequests()
        {
            InitializeComponent();
        }
        private void AllNewRequests_Load(object sender, EventArgs e)
        {
            ids_client = SQLRequests.SelectRequest(
               "select владелец from Заявка where статус = 'новые' order by дата_формирования desc",
               new string[] { }, new string[] { });

            List<string> surname = new List<string>();
            List<string> name = new List<string>();


            for (int i = 0; i < ids_client.Count; i++)
            {
                List<string> s = SQLRequests.SelectRequest(
                   "select фамилия from Клиент where id = @id",
                   new string[] { "id" }, new string[] { ids_client[i] });
                surname.Add(s[0]);

                List<string> n = SQLRequests.SelectRequest(
                   "select имя from Клиент where id = @id",
                   new string[] { "id" }, new string[] { ids_client[i] });
                name.Add(n[0]);

            }

            dates = SQLRequests.SelectRequest(
               "select дата_формирования from Заявка where статус = 'новые' order by дата_формирования desc",
               new string[] { }, new string[] { });

            List<string> about = SQLRequests.SelectRequest(
               "select описание from Заявка where статус = 'новые' order by дата_формирования desc",
               new string[] { }, new string[] { });

            List<string> ids_about = SQLRequests.SelectRequest(
               "select id_описание from Заявка where статус = 'новые' order by дата_формирования desc",
               new string[] { }, new string[] { });

            List<string> types = new List<string>();

            List<string> budzet = new List<string>();

            for (int i = 0; i < ids_about.Count; i++)
            {

                //List<string> t = SQLRequests.SelectRequest(
                //   "select тип_рекламы from описание_заявки where id = @id",
                //   new string[] {"id" }, new string[] { ids_about[i] });
                //types.Add(t[0]);

                List<string> b = SQLRequests.SelectRequest(
                   "select бюджет from описание_заявки where id = @id",
                   new string[] {"id" }, new string[] { ids_about[i] });
                budzet.Add(b[0]);
            }

            //surname, name, otch, dates, about, types, budzet
            Label[] labels = new Label[] { label2, label3, label4, label5, label6,
            label7, label8, label9, label10, label11};
            add = new Button[] { button1, button4, button6, button8, button10,
            button12, button14, button16, button18, button20};
            remove = new Button[] { button2, button3, button5, button7, button9,
            button11, button13, button15, button17, button19 };
            
            for (int i = 0; i < 10; i++)
            {
                if (surname.Count == i) break;

                labels[i].Text = "ФИО: " + surname[i] + " " + name[i];
                    //+ " " + otch[i] + "\n";
                labels[i].Text += " Дата формирования заявки: " + dates[i].Substring(0, 11);
                labels[i].Text += 
                    //"\nТип: " + types[i] +
                    ". Бюджет: " + budzet[i];
                labels[i].Text += "\nОписание заявки: " + about[i];
                if (about[i] == "")
                {
                    labels[i].Text += "отсутствует";
                }

            }
        }
        Button[] add;
        Button[] remove;
        List<string> ids_client;
        List<string> dates;
        private void AddRequest(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string name = "";
            try { name = button.Name.Substring(6, 2); } catch { name = button.Name.Substring(6, 1); }

            string vladelec = "";
            string date = "";
            if (name == "1")
            {
                vladelec = ids_client[0]; date = dates[0];
            }

            else { 
                vladelec = ids_client[Convert.ToInt32(name) / 2 - 1];
                date = dates[Convert.ToInt32(name) / 2 - 1];
            }
            if(vladelec == "" || date == "")
            {
                MessageBox.Show("Непредвиденная ошибка");
                return;
            }

            DateTime dt = DateTime.Now;

            List<string> update_table1 = SQLRequests.SelectRequest(
                "update Заявка set дата_изменения_статуса = @d where владелец = @id and дата_формирования = @d2  and статус = 'новые'",
                new string[] { "d", "id", "d2" }, new string[] { dt.ToString(), vladelec, date });

            List<string> update_table2 = SQLRequests.SelectRequest(
                "update Заявка set статус = 'на выполнении' where владелец = @id and дата_формирования = @d2 and статус = 'новые'",
                new string[] { "id", "d2" }, new string[] { vladelec, date });

            MessageBox.Show("Заявка принята");
            this.AllNewRequests_Load(sender, e);

        }
        private void RemoveRequest(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string name = "";
            try { name = button.Name.Substring(6, 2); } catch { name = button.Name.Substring(6, 1); }

            string vladelec = "";
            string date = "";
            if (name == "2") { vladelec = ids_client[0]; date = dates[0]; }
            else
            {
                vladelec = ids_client[(Convert.ToInt32(name) - 1) / 2];
                date = dates[(Convert.ToInt32(name) - 1)/2];
            }

            if (vladelec == "" || date == "")
            {
                MessageBox.Show("Непредвиденная ошибка");
                return;
            }

            DateTime dt = DateTime.Now;

            List<string> update_table1 = SQLRequests.SelectRequest(
                "update Заявка set дата_изменения_статуса = @d where владелец = @id and дата_формирования = @d2 and статус = 'новые'",
                new string[] { "d", "id", "d2" }, new string[] { dt.ToString(), vladelec, date });

            List<string> update_table2 = SQLRequests.SelectRequest(
                "update Заявка set статус = 'отклоненные' where владелец = @id and дата_формирования = @d2 and статус = 'новые'",
                new string[] { "id", "d2" }, new string[] { vladelec, date });

            MessageBox.Show("Заявка отклонена");
            this.AllNewRequests_Load(sender, e);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
