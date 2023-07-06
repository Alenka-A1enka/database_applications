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
    public partial class Illness : Form
    {
        public Illness()
        {
            InitializeComponent();
        }

        private void Illness_Load(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Статистика в разрезе заболеваний
            int index = comboBox1.SelectedIndex;
            string ill = comboBox1.Text;

            MessageBox.Show("Ожидайте выгрузки данных");
           

            //кол-во заболевших по месяцам

            List<string> months = SQLRequests.SelectRequest(
                        "select дата_приема from АМБУЛАТОРНАЯ_КАРТА where диагноз = @d order by дата_приема",
                        new string[] { "d" }, new string[] { ill });

            int[] counts = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach(string s in months)
            {
                int ind = Convert.ToInt32(s.Substring(3, 2));
                counts[ind - 1]++;

            }
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.TypeText("Количество пациентов, поступивших в течении года: " +
                "\n Январь: " + counts[0] +
                "\n Ферваль: " + counts[1] +
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

            //возраст заболевших

                      List<string> min = SQLRequests.SelectRequest(
                        "select max(дата_рождения) from ПАЦИЕНТ where ИДЕНТИФИКАТОР_ПАЦИЕНТА in (select идентификатор_пациента from АМБУЛАТОРНАЯ_КАРТА where диагноз = @d)",
                        new string[] { "d" }, new string[] { ill });

            List<string> max = SQLRequests.SelectRequest(
                        "select min(дата_рождения) from ПАЦИЕНТ where ИДЕНТИФИКАТОР_ПАЦИЕНТА in (select идентификатор_пациента from АМБУЛАТОРНАЯ_КАРТА where диагноз = @d)",
                        new string[] { "d" }, new string[] { ill });

            int age1 = Convert.ToInt32(min[0].Substring(6, 4));
            int age2 = Convert.ToInt32(max[0].Substring(6, 4));

            wordApp.Selection.TypeText("\n\nВозрастной диапазон: от " + (2022 - age1) + " до " + 
                (2022 - age2));

        }
    }
}
