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

namespace Поликлиника
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new AdminStatistic();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //выводим отчет для распечатывания
            //заполняемость пациентами по месяцам
            MessageBox.Show("Ожидайте выгрузки данных");

            List<string> counts = SQLRequests.SelectRequest(
              "select count(*) from АМБУЛАТОРНАЯ_КАРТА group by дата_приема",
              new string[] { }, new string[] { });

            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.TypeText("Количество пациентов, поступивших в течении года: " +
                "\n Январь: " + counts[0] + 
                "\n Февраль: " + counts[1] +
                "\n Март: " + counts[2] +
                "\n Апрель: " + counts[3] +
                "\n Май: " + counts[4] +
                "\n Июнь: " + counts[5] +
                "\n Июль: " + counts[6] +
                "\n Август: " + counts[7] +
                "\n Сентябрь: " + counts[8] +
                "\n Октябрь: " + counts[9] +
                "\n Ноябрь: " + counts[10] +
                "\n Декабрь: " + counts[11]);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Illness();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
