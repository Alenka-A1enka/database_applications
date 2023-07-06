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
    public partial class DoctorReception : Form
    {
        public DoctorReception()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //получаем идентификатор пациента по фамилии

            List<string> id = SQLRequests.SelectRequest(
               "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @name",
               new string[] { "name" }, new string[] { lastname.Text });

            if (id.Count == 0)
            {
                MessageBox.Show("Такого пациента нет!");
                return;
            }

            //находим результаты анализов за последний месяц

            DateTime datetime = DateTime.Now;
            datetime = datetime.AddMonths(-1);

            List<string> results = SQLRequests.SelectRequest(
               "select основные_результаты from ЗАПИСЬ_ИССЛЕДОВАНИЯ where идентификатор_пациента = @id and дата > @time and основные_результаты is not null",
               new string[] { "id", "time" }, new string[] { id[0], datetime.ToString().Substring(0, 10) });

            List<string> results_dates = SQLRequests.SelectRequest(
               "select дата from ЗАПИСЬ_ИССЛЕДОВАНИЯ where идентификатор_пациента = @id and дата > @time and основные_результаты is not null",
               new string[] { "id", "time" }, new string[] { id[0], datetime.ToString().Substring(0, 10) });

            int location = 230;
            for (int i = 0; i < results.Count; i++)
            {
                //72; 524

                Label label = new Label();
                label.AutoSize = true;
                //Microsoft Sans Serif; 10,8pt
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                label.ForeColor = System.Drawing.Color.White;
                label.Location = new System.Drawing.Point(45, location);
                label.Text = results[i] + " (" + results_dates[i].Substring(0, 10) + ")";

                location += 45;
                this.tabPage1.Controls.Add(label);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            List<string> id = SQLRequests.SelectRequest(
               "select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where фамилия = @name",
               new string[] { "name" }, new string[] { textBox1.Text });
            if (id.Count == 0)
            {
                MessageBox.Show("Такого пациента нет!");
                return;
            }

            
                List<string> insert_lechenie = SQLRequests.SelectRequest(
               "insert into ЛЕЧЕНИЕ(лечение) values(@l)",
               new string[] { "l" }, new string[] { richTextBox1.Text });
            List<string> last_id = SQLRequests.SelectRequest(
              "select ИДЕНТИФИКАТОР from ЛЕЧЕНИЕ where лечение = @l",
              new string[] { "l" }, new string[] { richTextBox1.Text });

            DateTime dt = DateTime.Now;
            
            List<string> insert_table = SQLRequests.SelectRequest(
           "insert into АМБУЛАТОРНАЯ_КАРТА (идентификатор_пациента, дата_приема, время_приема, диагноз, идентификатор_лечения) values(@pac, @date, @time, @d, @l)",
           new string[] { "pac", "date", "time", "d", "l" }, new string[] { id[0], dt.ToString(), dt.TimeOfDay.ToString().Substring(0, 8), textBox2.Text, last_id[0] });

            MessageBox.Show("Лечение добавлено");
            
        }
    }
}
