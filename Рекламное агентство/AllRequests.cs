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
    public partial class AllRequests : Form
    {
        string type;
        public AllRequests(string type)
        {
            InitializeComponent();

            this.type = type;
            //на выполнении
            //завершенные
            //отклоненные
        }

        List<Button> buttons;
        private void AllRequests_Load(object sender, EventArgs e)
        {
            if (type == "завершенные")
            {
                label1.Text = "Завершенные заявки";

                List<string> ids_client = SQLRequests.SelectRequest(
              "select владелец from Заявка where статус = 'завершенные'",
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

                List<string> dates = SQLRequests.SelectRequest(
                   "select дата_формирования from Заявка where статус = 'завершенные'",
                   new string[] { }, new string[] { });

                List<string> about = SQLRequests.SelectRequest(
                   "select описание from Заявка where статус = 'завершенные'",
                   new string[] { }, new string[] { });

                //List<string> ids_about = SQLRequests.SelectRequest(
                //   "select id_описание from Заявка where статус = 'завершенные'",
                //   new string[] { }, new string[] { });

                //List<string> types = new List<string>();

                //List<string> budzet = new List<string>();

                //for (int i = 0; i < ids_about.Count; i++)
                //{

                //    List<string> t = SQLRequests.SelectRequest(
                //       "select тип_рекламы from описание_заявки where id = @id",
                //       new string[] { "id" }, new string[] { ids_about[i] });
                //    types.Add(t[0]);

                //    List<string> b = SQLRequests.SelectRequest(
                //       "select бюджет from описание_заявки where id = @id",
                //       new string[] { "id" }, new string[] { ids_about[i] });
                //    budzet.Add(b[0]);
                //}

                List<string> dates2 = SQLRequests.SelectRequest(
     "select дата_изменения_статуса from Заявка where статус = 'завершенные'",
     new string[] { }, new string[] { });

                //surname, name, otch, dates, types, budzet, dates, about
                Label label = new Label();
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                label.Location = new System.Drawing.Point(110, 50);


                for (int i = 0; i < surname.Count; i++)
                {
                    label.Text += "\n\n\nФИО клиента: " + surname[i] + " " + name[i] + 
                        "\nДата формирования заявки: " + dates[i].Substring(0, 11) +
                        "\nДата завершения выполнения заявки: " + dates2[i].Substring(0, 11) +
                        //"\nБюджет: " + 
                        //budzet[i] 
                         "\nОписание: ";
                    try
                    {
                        label.Text += about[i].Substring(0, 40);
                        try
                        {
                            label.Text += "\n" + about[i].Substring(40);
                        }
                        catch { }
                    }
                    catch
                    {
                        label.Text += about[i];
                    }
                }


                this.Controls.Add(label);



            }
            if (type == "отклоненные")
            {
                label1.Text = "Отклоненные заявки";

                List<string> ids_client = SQLRequests.SelectRequest(
              "select владелец from Заявка where статус = 'отклоненные'",
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

                List<string> dates = SQLRequests.SelectRequest(
                   "select дата_формирования from Заявка where статус = 'отклоненные'",
                   new string[] { }, new string[] { });

                //List<string> about = SQLRequests.SelectRequest(
                //   "select описание from Заявка where статус = 'отклоненные'",
                //   new string[] { }, new string[] { });

                List<string> ids_about = SQLRequests.SelectRequest(
                   "select id_описание from Заявка where статус = 'отклоненные'",
                   new string[] { }, new string[] { });

                List<string> types = new List<string>();

                List<string> budzet = new List<string>();

                for (int i = 0; i < ids_about.Count; i++)
                {

                    List<string> t = SQLRequests.SelectRequest(
                       "select тип_рекламы from описание_заявки where id = @id",
                       new string[] { "id" }, new string[] { ids_about[i] });
                    types.Add(t[0]);

                    List<string> b = SQLRequests.SelectRequest(
                       "select бюджет from описание_заявки where id = @id",
                       new string[] { "id" }, new string[] { ids_about[i] });
                    budzet.Add(b[0]);
                }

                List<string> dates2 = SQLRequests.SelectRequest(
     "select дата_изменения_статуса from Заявка where статус = 'отклоненные'",
     new string[] { }, new string[] { });

                //surname, name, otch, dates, dates2, budzet, about
                Label label = new Label();
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                label.Location = new System.Drawing.Point(110, 50);


                for (int i = 0; i < surname.Count; i++)
                {
                    label.Text += "\n\n\nФИО клиента: " + surname[i] + " " + name[i] +
                        "\nДата формирования заявки: " + dates[i].Substring(0, 11) +
                        "\nДата завершения выполнения заявки: " + dates2[i].Substring(0, 11) +
                        "\nБюджет: " + budzet[i];
                        //"\nОписание: ";
                    //try
                    //{
                    //    label.Text += about[i].Substring(0, 40);
                    //    try
                    //    {
                    //        label.Text += "\n" + about[i].Substring(40);
                    //    }
                    //    catch { }
                    //}
                    //catch
                    //{
                    //    label.Text += about[i];
                    //}
                }


                this.Controls.Add(label);

            }
            if (type == "на выполнении")
            {
                label1.Text = "Заявки на выполнении";

                List<string> ids_client = SQLRequests.SelectRequest(
              "select владелец from Заявка where статус = 'на выполнении'",
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

                List<string> dates = SQLRequests.SelectRequest(
                   "select дата_формирования from Заявка where статус = 'на выполнении'",
                   new string[] { }, new string[] { });

                List<string> about = SQLRequests.SelectRequest(
                   "select описание from Заявка where статус = 'на выполнении'",
                   new string[] { }, new string[] { });

                List<string> ids_about = SQLRequests.SelectRequest(
                   "select id_описание from Заявка where статус = 'на выполнении'",
                   new string[] { }, new string[] { });

                List<string> types = new List<string>();

                List<string> budzet = new List<string>();

                for (int i = 0; i < ids_about.Count; i++)
                {

                    List<string> t = SQLRequests.SelectRequest(
                       "select тип_рекламы from описание_заявки where id = @id",
                       new string[] { "id" }, new string[] { ids_about[i] });
                    types.Add(t[0]);

                    List<string> b = SQLRequests.SelectRequest(
                       "select бюджет from описание_заявки where id = @id",
                       new string[] { "id" }, new string[] { ids_about[i] });
                    budzet.Add(b[0]);
                }

     //           List<string> dates2 = SQLRequests.SelectRequest(
     //"select дата_изменения_статуса from Заявка where статус = 'на выполнении'",
     //new string[] { }, new string[] { });

                //surname, name, otch, dates, dates2, budzet, about

                int start = 50;
                int start_button = 230;
                buttons = new List<Button>();
                for (int i = 0; i < surname.Count; i++)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    label.Location = new System.Drawing.Point(110, start);


                label.Text += "\n\n\nФИО клиента: " + surname[i] + " " + name[i] + 
                         //"\nДата формирования заявки: " + dates[i].Substring(0, 11) +
                        //"\nДата принятия заявки к выполнению: " + dates2[i].Substring(0, 11) +
                        "\nБюджет: " + budzet[i] + "\nОписание: ";
                    try
                    {
                        label.Text += about[i].Substring(0, 40);
                        try
                        {
                            label.Text += "\n" + about[i].Substring(40);
                        }
                        catch { }
                    }
                    catch
                    {
                        label.Text += about[i];
                    }
                    this.Controls.Add(label);
                    start += 200;

                    Button button = new Button();
                    button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button.Location = new System.Drawing.Point(110, start_button);
                    button.Name = dates[i].Substring(0, 10) + ids_client[i];
                    button.Size = new System.Drawing.Size(279, 39);
                    button.TabIndex = 20;
                    button.Text = "Завершить выполнение";
                    button.UseVisualStyleBackColor = false;
                    button.Click += new System.EventHandler(this.buttons_Click);
                    buttons.Add(button);

                    this.Controls.Add(button);
                    start_button += 200;
                }
            }
        }
        private void buttons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string result = button.Name;

            string date = result.Substring(0, 10);
            string id_client = result.Substring(10);

            DateTime dt = DateTime.Now;

            List<string> update_date = SQLRequests.SelectRequest(
                     "update Заявка set дата_изменения_статуса = @d where владелец = @id and дата_формирования = @date and статус = 'на выполнении'",
                     new string[] { "d", "id", "date" }, 
                     new string[] { dt.ToString(), id_client, date });

            
            List<string> req_id = SQLRequests.SelectRequest(
                   "select id from Заявка where владелец = @id and дата_формирования = @d",
                   new string[] { "id", "d" },
                   new string[] { id_client, date });

            List<string> update_status = SQLRequests.SelectRequest(
                    "update Заявка set статус = 'завершенные' where id = @id",
                    new string[] { "id" }, 
                    new string[] { req_id[0] });

            MessageBox.Show("Выполнение заявки завершено");

        }
    }
}
