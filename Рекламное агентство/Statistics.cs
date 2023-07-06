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

namespace Рекламное_агентство
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int[] counts;
        int[] counts2;
        private void Statistics_Load(object sender, EventArgs e)
        {
            List<string> dates = SQLRequests.SelectRequest(
           "select дата_формирования from Заявка where дата_формирования > '01-01-2022' order by дата_формирования",
           new string[] { }, new string[] { });

            List<int> month = new List<int>();
            string s = "";
            foreach (string date in dates)
            {
                month.Add(Convert.ToInt32(date.Substring(3, 2)));
            }

            counts = new int[12];
            foreach (int i in month)
            {
                counts[i - 1]++;
            }
            Label[] labels = new Label[] { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12 };

            for (int i = 0; i < counts.Length; i++)
            {
                labels[i].Text = counts[i].ToString();
            }



            List<string> status = SQLRequests.SelectRequest(
          "select статус from Заявка where дата_формирования > '01-11-2022'",
          new string[] { }, new string[] { });

            int new_req = 0;
            int remove_req = 0;
            int current_req = 0;
            int ready_req = 0;
            foreach (string st in status)
            {
                if (st == "завершенные") ready_req++;
                if (st == "отклоненные") remove_req++;
                if (st == "на выполнении") current_req++;
                if (st == "новые") new_req++;

            }
            counts2 = new int[] { new_req, remove_req, ready_req, current_req };
            lb1.Text = new_req.ToString();
            lb2.Text = remove_req.ToString();
            lb3.Text = ready_req.ToString();
            lb4.Text = current_req.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаём объект - экземпляр нашего приложения
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочей книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Cells[1, 1] = "Месяц";
            workSheet.Cells[2, 1] = "Январь";
            workSheet.Cells[3, 1] = "Февраль";
            workSheet.Cells[4, 1] = "Март";

            workSheet.Cells[5, 1] = "Апрель";
            workSheet.Cells[6, 1] = "Май";
            workSheet.Cells[7, 1] = "Июнь";

            workSheet.Cells[8, 1] = "Июль";
            workSheet.Cells[9, 1] = "Август";
            workSheet.Cells[10, 1] = "Сентябрь";

            workSheet.Cells[11, 1] = "Октябрь";
            workSheet.Cells[12, 1] = "Ноябрь";
            workSheet.Cells[13, 1] = "Декабрь";

            workSheet.Cells[1, 2] = "Кол-во заявок";
            for (int i = 2; i < 14; i++)
            {
                workSheet.Cells[i, 2] = counts[i - 2];
            }


            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создаём объект - экземпляр нашего приложения
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочей книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Cells[1, 1] = "Тип заявки";
            workSheet.Cells[2, 1] = "Новые";
            workSheet.Cells[3, 1] = "Отклоненные";
            workSheet.Cells[4, 1] = "Завершенные";

            workSheet.Cells[5, 1] = "На выполнении";

            workSheet.Cells[1, 2] = "Кол-во заявок";
            for (int i = 2; i < 6; i++)
            {
                workSheet.Cells[i, 2] = counts2[i - 2];
            }


            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            List<string> all_sums = new List<string>();
            for (int i = 1; i < 12; i++)
            {
                List<string> current_sum = SQLRequests.SelectRequest(
          "select sum(бюджет) from описание_заявки where id in (select id from Заявка where статус in ('завершенные', 'на выполнении') and дата_формирования >= @d1 and дата_формирования < @d2)",
          new string[] { "d1", "d2" }, new string[] { "01." + i + ".2022", "01." + (i + 1) + ".2022" });


                all_sums.Add(current_sum[0]);

            }
            List<string> december = SQLRequests.SelectRequest(
          "select sum(бюджет) from описание_заявки where id in (select id from Заявка where статус in ('завершенные', 'на выполнении') and дата_формирования >= @d1)",
          new string[] { "d1" }, new string[] { "01.12.2022" });
            all_sums.Add(december[0]);




            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = all_sums[0];
            ObjWorkSheet.Cells[3, 2] = all_sums[1];
            ObjWorkSheet.Cells[3, 3] = all_sums[2];

            ObjWorkSheet.Cells[3, 4] = all_sums[3];
            ObjWorkSheet.Cells[3, 5] = all_sums[4];
            ObjWorkSheet.Cells[3, 6] = all_sums[5];

            ObjWorkSheet.Cells[3, 7] = all_sums[6];
            ObjWorkSheet.Cells[3, 8] = all_sums[7];
            ObjWorkSheet.Cells[3, 9] = all_sums[8];

            ObjWorkSheet.Cells[3, 10] = all_sums[9];
            ObjWorkSheet.Cells[3, 11] = all_sums[10];
            ObjWorkSheet.Cells[3, 12] = all_sums[11];
            //ObjWorkSheet.Cells[3, 4] = "4";
            //ObjWorkSheet.Cells[3, 5] = "3";

            ObjWorkSheet.Cells[1, 1] = "Выручка по месяцам";
            ObjWorkSheet.Cells[2, 1] = "Январь";
            ObjWorkSheet.Cells[2, 2] = "Февраль";
            ObjWorkSheet.Cells[2, 3] = "Март";

            ObjWorkSheet.Cells[2, 4] = "Апрель";
            ObjWorkSheet.Cells[2, 5] = "Май";
            ObjWorkSheet.Cells[2, 6] = "Июнь";

            ObjWorkSheet.Cells[2, 7] = "Июль";
            ObjWorkSheet.Cells[2, 8] = "Август";
            ObjWorkSheet.Cells[2, 9] = "Сентябрь";

            ObjWorkSheet.Cells[2, 10] = "Октябрь";
            ObjWorkSheet.Cells[2, 11] = "Ноябрь";
            ObjWorkSheet.Cells[2, 12] = "Декабрь";
            //ObjWorkSheet.Cells[2, 4] = "4";
            //ObjWorkSheet.Cells[2, 5] = "5";
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
            //

            var excelcells = ObjWorkSheet.get_Range("A3", "L3");
            //И выбираем их
            excelcells.Select();
            //Создаем объект Excel.Chart диаграмму по умолчанию
            Excel.Chart excelchart = (Excel.Chart)ObjExcel.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Выбираем диграмму - отображаем лист с диаграммой
            excelchart.Activate();
            excelchart.Select(Type.Missing);
            //Изменяем тип диаграммы
            ObjExcel.ActiveChart.ChartType = Excel.XlChartType.xlColumnStacked;
            //Создаем надпись - Заглавие диаграммы
            ObjExcel.ActiveChart.HasTitle = true;
            ObjExcel.ActiveChart.ChartTitle.Text
                       = "Выручка";
            ObjExcel.ActiveChart.FullSeriesCollection(1).XValues = "=Лист1!$A$2:$L$2";
            //Меняем шрифт, можно поменять и другие параметры шрифта
            ObjExcel.ActiveChart.ChartTitle.Font.Size = 14;
            ObjExcel.ActiveChart.ChartTitle.Font.Color = 255;
            //Обрамление для надписи c тенями
            ObjExcel.ActiveChart.ChartTitle.Shadow = true;
            ObjExcel.ActiveChart.ChartTitle.Border.LineStyle
                         = Excel.Constants.xlSolid;
            //Даем названия осей
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Период";
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Сумма";
            //Координатная сетка - оставляем только крупную сетку
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
               Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
              Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
              Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
              Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
            ObjExcel.ActiveChart.HasLegend = true;
            //Расположение легенды
            ObjExcel.ActiveChart.Legend.Position
                       = Excel.XlLegendPosition.xlLegendPositionLeft;
            //Можно изменить шрифт легенды и другие параметры 
            ((Excel.LegendEntry)ObjExcel.ActiveChart.Legend.LegendEntries(1)).Font.Size = 12;
            Excel.SeriesCollection seriesCollection =
             (Excel.SeriesCollection)ObjExcel.ActiveChart.SeriesCollection(Type.Missing);
            Excel.Series series = seriesCollection.Item(1);
            series.Name = "Сумма";
            series.Name = "Период";

            //Перемещаем диаграмму на лист 1
            ObjExcel.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1");
            //Получаем ссылку на лист 1
            var excelsheets = ObjWorkBook.Worksheets;
            ObjWorkSheet = (Excel.Worksheet)excelsheets.get_Item(1);
            //Перемещаем диаграмму в нужное место
            ObjWorkSheet.Shapes.Item(1).IncrementLeft(-201);
            ObjWorkSheet.Shapes.Item(1).IncrementTop((float)20.5);
            //Задаем размеры диаграммы
            ObjWorkSheet.Shapes.Item(1).Height = 550;
            ObjWorkSheet.Shapes.Item(1).Width = 500;


            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;

        }
    }
}
