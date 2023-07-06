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
    public partial class AdminAnalitic : Form
    {
        Bitmap bmp;
        Graphics g;
        public AdminAnalitic()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp = (Bitmap)pictureBox1.Image;
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
        }

        private void AdminAnalitic_Load(object sender, EventArgs e)
        {
            //Ежедневное количество открытых больничных листов за неделю
            //получаем текущую дату и день недели
            DateTime[] datetime_dates = new DateTime[7];
            Label[] label_dates = new Label[7] { lab1, lab2, lab3, lab4, lab5, lab6, lab7 };
            Label[] label_counts = new Label[7] { lb1, lb2, lb3, lb4, lb5, lb6, lb7 };

            datetime_dates[0] = DateTime.Now;
            for (int i = 1; i < 7; i++)
            {
                datetime_dates[i] = datetime_dates[0].AddDays(-i);
            }
            string[] dates = new string[7];
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i] = datetime_dates[i].ToShortDateString();
                label_dates[i].Text = dates[i].Substring(0, 5);
            }



            //для каждого дня недели получаем кол-во открытых больничных листов
            int[] counts = new int[7];
            for (int i = 0; i < 7; i++)
            {
                List<string> current_count = SQLRequests.SelectRequest(
                   "select count(*) from БОЛЬНИЧНЫЕ_ЛИСТЫ where дата_открытия = @date",
                   new string[] { "date" }, new string[] { dates[i] });
                counts[i] = Convert.ToInt32(current_count[0]);
                label_counts[i].Text = counts[i].ToString();
            }

            //g.DrawLine(new Pen(Color.Black, 1), new Point(40, 200), new Point(40, 50));
            //g.DrawLine(new Pen(Color.Black, 1), new Point(40, 50), new Point(60, 50));
            //g.DrawLine(new Pen(Color.Black, 1), new Point(60, 200), new Point(60, 50));
            int x_startPoint = 10;
            int y_startPoint = 200;
            int y_endPoint = 50;
            int x_column = 20;
            int x_step = 50;
            int k = Convert.ToInt32((y_startPoint - y_endPoint) / counts.Max());
            for (int i = 0; i < 7; i++)
            {
                if (counts[i] == 0)
                {
                    x_startPoint += x_step;
                    continue;
                }
                g.DrawLine(new Pen(Color.White, 1),
                    new Point(x_startPoint + x_step, y_startPoint),
                    new Point(x_startPoint + x_step, k * (counts.Max() - counts[i])));
                g.DrawLine(new Pen(Color.White, 1),
                    new Point(x_startPoint + x_step, k * (counts.Max() - counts[i])),
                    new Point(x_startPoint + x_step + x_column, k * (counts.Max() - counts[i])));
                g.DrawLine(new Pen(Color.White, 1),
                    new Point(x_startPoint + x_step + x_column, y_startPoint),
                    new Point(x_startPoint + x_step + x_column, k * (counts.Max() - counts[i])));

                x_startPoint += x_step;
            }


            pictureBox1.Image = bmp;


            //Пациенты, находящиеся на больничном на данный момент
            //получаем все идентификаторы пациентов на больничном

            List<string> identetis = SQLRequests.SelectRequest(
                   "select идентификатор_пациента from БОЛЬНИЧНЫЕ_ЛИСТЫ where дата_закрытия is null",
                   new string[] { }, new string[] { });

            //ФИО пациентов

            string[] full_names = new string[identetis.Count];

            for (int i = 0; i < identetis.Count; i++)
            {
                List<string> last_name = SQLRequests.SelectRequest(
                   "select фамилия from ПАЦИЕНТ where ИДЕНТИФИКАТОР_ПАЦИЕНТА = @id",
                   new string[] {"id"}, new string[] { identetis[i] });

                List<string> name = SQLRequests.SelectRequest(
                   "select имя from ПАЦИЕНТ where ИДЕНТИФИКАТОР_ПАЦИЕНТА = @id",
                   new string[] { "id" }, new string[] { identetis[i] });

                List<string> middle_name = SQLRequests.SelectRequest(
                   "select отчество from ПАЦИЕНТ where ИДЕНТИФИКАТОР_ПАЦИЕНТА = @id",
                   new string[] { "id" }, new string[] { identetis[i] });

                full_names[i] = last_name[0] + " " + name[0] + " " + middle_name[0];

            }
            int location = 430;
            for (int i = 0; i < full_names.Length; i++)
            {
                //72; 524

                Label label = new Label();
                label.AutoSize = true;
                //Microsoft Sans Serif; 10,8pt
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                label.ForeColor = System.Drawing.Color.White;
                label.Location = new System.Drawing.Point(45, location);
                label.Text = (i+1) + ". " + full_names[i];

                location += 45;
                this.Controls.Add(label);
            }


        }
    }
}
