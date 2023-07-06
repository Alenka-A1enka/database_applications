using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Поликлиника
{
    public partial class AdminStatistic : Form
    {
        public AdminStatistic()
        {
            InitializeComponent();
        }
        List<string> group1;
        List<string> group2;
        List<string> group3;
        List<string> group4;
        List<string> group5;

        private void AdminStatistic_Load(object sender, EventArgs e)
        {
            //--аллергия, бронхит, заболевание сердца, ОРВИ, отит, Эндокринное заболевание
            group1 = SQLRequests.SelectRequest(
               "select count(диагноз) from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента in " +
               "(select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where дата_рождения > '01.01.2002') " +
               "group by диагноз",
               new string[] { }, new string[] { });

            group2 = SQLRequests.SelectRequest(
               "select count(диагноз) from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента in " +
               "(select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where дата_рождения < '01.01.2002' " +
               "and дата_рождения > '01.01.1992') group by диагноз",
               new string[] { }, new string[] { });

            group3 = SQLRequests.SelectRequest(
            "select count(диагноз) from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента in " +
            "(select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where дата_рождения < '01.01.1992' " +
            "and дата_рождения > '01.01.1982') group by диагноз",
            new string[] { }, new string[] { });

            group4 = SQLRequests.SelectRequest(
            "select count(диагноз) from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента in " +
            "(select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where дата_рождения < '01.01.1982' " +
            "and дата_рождения > '01.01.1972') group by диагноз",
            new string[] { }, new string[] { });

            group5 = SQLRequests.SelectRequest(
            "select count(диагноз) from БОЛЬНИЧНЫЕ_ЛИСТЫ where идентификатор_пациента in " +
            "(select ИДЕНТИФИКАТОР_ПАЦИЕНТА from ПАЦИЕНТ where дата_рождения < '01.01.1972') " +
            "group by диагноз",
            new string[] { }, new string[] { });



        }
        Label[] labels = new Label[0];
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //аллергия, бронхит, заболевание сердца, ОРВИ, отит, Эндокринное заболевание
            labels = new Label[] { lab1, lab2, lab3, lab4, lab5, lab6 };

            List<string>[] groups = new List<string>[] { group1, group2, group3, group4, group5 };
            int index = comboBox1.SelectedIndex;

            List<string> current = groups[index];

            int sum = 0;
            for (int i = 0; i < current.Count; i++)
            {
                sum += Convert.ToInt32(current[i]);
            }

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = Math.Round(Convert.ToDouble(Convert.ToDouble(current[i]) / sum) * 100, 1) + "%";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);


            workSheet.Cells[1, 1] = "Возрастная группа: " + comboBox1.Text;
            workSheet.Cells[2, 1] = "Аллергия";
            workSheet.Cells[3, 1] = "Бронхит";
            workSheet.Cells[4, 1] = "Заболевание сердца";

            workSheet.Cells[5, 1] = "ОРВИ";
            workSheet.Cells[6, 1] = "Отит";
            workSheet.Cells[7, 1] = "Эндокринные заболевания";

            workSheet.Cells[1, 2] = "Процент заболеваемости";
            try
            {
                for (int i = 2; i < 8; i++)
                {
                    workSheet.Cells[i, 2] = labels[i - 2].Text;
                }

                excelApp.Visible = true;
                excelApp.UserControl = true;
            }
            catch { }
        }
    }
}
