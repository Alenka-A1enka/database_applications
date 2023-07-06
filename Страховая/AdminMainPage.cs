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

namespace Страховая
{
    public partial class AdminMainPage : Form
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }
        int[] counts;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            textBox1.Visible = true;

            int index = comboBox1.SelectedIndex;
            index++;

            List<string> count1 = SQLRequests.SelectRequest(
              "select sum(внесенная_сумма) from Договор where id_агент = @id",
              new string[] { "id" }, new string[] { index.ToString() });

            textBox1.Text = count1[0];

        }

        private void AdminMainPage_Load(object sender, EventArgs e)
        {
            counts = new int[3];
            for (int i = 0; i < counts.Length; i++)
            {
                List<string> count1 = SQLRequests.SelectRequest(
              "select sum(внесенная_сумма) from Договор where id_агент = @id",
              new string[] { "id" }, new string[] { (i + 1).ToString() });
                counts[i] = Convert.ToInt32(count1[0]);
            }

            DateTime dt = DateTime.Now;
            DateTime dt2 = dt.AddDays(-7); 

            List<string> live_1 = SQLRequests.SelectRequest(
               "select count(*) from Договор where id_вид = 'страхование жизни' and дата_составления > @date",
               new string[] { "date" }, new string[] { "01-01-2022" });

            List<string> live_2 = SQLRequests.SelectRequest(
               "select count(*) from Договор where id_вид = 'страхование жизни' and дата_составления > @date",
               new string[] { "date" }, new string[] { "01-11-2022" });

            List<string> live_3 = SQLRequests.SelectRequest(
               "select count(*) from Договор where id_вид = 'страхование жизни' and дата_составления > @date",
               new string[] { "date" }, new string[] { dt2.ToString() });

            List<string> house_1 = SQLRequests.SelectRequest(
               "select count(*) from Договор where id_вид = 'страхование недвижимости' and дата_составления > @date",
               new string[] { "date" }, new string[] { "01-01-2022" });

            List<string> house_2 = SQLRequests.SelectRequest(
               "select count(*) from Договор where id_вид = 'страхование недвижимости' and дата_составления > @date",
               new string[] { "date" }, new string[] { "01-11-2022" });

            List<string> house_3 = SQLRequests.SelectRequest(
               "select count(*) from Договор where id_вид = 'страхование недвижимости' and дата_составления > @date",
               new string[] { "date" }, new string[] { dt2.ToString() });

            live1.Text = live_1[0];
            live2.Text = live_2[0];
            live3.Text = live_3[0];

            house1.Text = house_1[0];
            house2.Text = house_2[0];
            house3.Text = house_3[0];


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

            workSheet.Cells[1, 2] = "Страхование жизни";
            workSheet.Cells[1, 3] = "Страхование недвижимости";

            workSheet.Cells[2, 1] = "За последний год";
            workSheet.Cells[3, 1] = "За последний месяц";
            workSheet.Cells[4, 1] = "За последнюю неделю";

            workSheet.Cells[2, 2] = live1.Text;
            workSheet.Cells[3, 2] = live2.Text;
            workSheet.Cells[4, 2] = live3.Text;

            workSheet.Cells[2, 3] = house1.Text;
            workSheet.Cells[3, 3] = house2.Text;
            workSheet.Cells[4, 3] = house3.Text;


            MessageBox.Show("Данные выгружены");


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

            workSheet.Cells[1, 2] = "Страхование жизни";
            workSheet.Cells[1, 3] = "Страхование недвижимости";

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


            List<string> dates_live = SQLRequests.SelectRequest(
   "select дата_составления from Договор where id_вид = 'страхование жизни' order by дата_составления",
   new string[] { }, new string[] { });

            List<string> dates_house = SQLRequests.SelectRequest(
   "select дата_составления from Договор where id_вид = 'страхование недвижимости' order by дата_составления",
   new string[] { }, new string[] { });


            List<int> month = new List<int>();
            string s = "";
            foreach (string date in dates_live)
            {
                month.Add(Convert.ToInt32(date.Substring(3, 2)));
            }
            int[] counts = new int[12];
            foreach (int i in month)
            {
                counts[i - 1]++;
            }


            List<int> month2 = new List<int>();
            string s2 = "";
            foreach (string date in dates_house)
            {
                month2.Add(Convert.ToInt32(date.Substring(3, 2)));
            }
            int[] counts2 = new int[12];
            foreach (int i in month2)
            {
                counts2[i - 1]++;
            }

            for (int i = 0; i < 12; i++)
            {
                workSheet.Cells[i + 2, 2] = counts[i];
            }

            for (int i = 0; i < 12; i++)
            {
                workSheet.Cells[i + 2, 3] = counts2[i];
            }


            MessageBox.Show("Данные выгружены");


            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
        private void GetCounts(ref int[] c1, ref int[] c2)
        {
            List<string> dates_live = SQLRequests.SelectRequest(
   "select дата_составления from Договор where id_вид = 'страхование жизни' order by дата_составления",
   new string[] { }, new string[] { });

            List<string> dates_house = SQLRequests.SelectRequest(
   "select дата_составления from Договор where id_вид = 'страхование недвижимости' order by дата_составления",
   new string[] { }, new string[] { });


            List<int> month = new List<int>();
            string s = "";
            foreach (string date in dates_live)
            {
                month.Add(Convert.ToInt32(date.Substring(3, 2)));
            }
            foreach (int i in month)
            {
                c1[i - 1]++;
            }


            List<int> month2 = new List<int>();
            string s2 = "";
            foreach (string date in dates_house)
            {
                month2.Add(Convert.ToInt32(date.Substring(3, 2)));
            }
            foreach (int i in month2)
            {
                c2[i - 1]++;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            int[] lives = new int[] {Convert.ToInt32(live3.Text),
            Convert.ToInt32(live2.Text),
            Convert.ToInt32(live1.Text)};

            int[] houses = new int[] {Convert.ToInt32(house3.Text),
            Convert.ToInt32(house2.Text),
            Convert.ToInt32(house1.Text)};

            double strach1 = lives[0] * 0.8 + lives[1] * 0.5 + lives[2] * 0.25;
            double strach2 = houses[0] * 0.8 + houses[1] * 0.5 + houses[2] * 0.25;

            if(strach1 > strach2) MessageBox.Show("Общий рейтинг:\n1. Страхование жизни ("+strach1+")\n2." +
                " Страхование недвижимости (" +strach2 + ")");
            else MessageBox.Show("Общий рейтинг:\n1. Страхование недвижимости (" + strach2 + ")\n2." +
                " Страхование жизни (" + strach1 + ")");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = live1.Text;
            ObjWorkSheet.Cells[3, 2] = live2.Text;
            ObjWorkSheet.Cells[3, 3] = live3.Text;
            //ObjWorkSheet.Cells[3, 4] = "4";
            //ObjWorkSheet.Cells[3, 5] = "3";
            ObjWorkSheet.Cells[2, 1] = "За последний год";
            ObjWorkSheet.Cells[2, 2] = "За последний месяц";
            ObjWorkSheet.Cells[2, 3] = "За последнюю неделю";
            //ObjWorkSheet.Cells[2, 4] = "4";
            //ObjWorkSheet.Cells[2, 5] = "5";
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
            //

            var excelcells = ObjWorkSheet.get_Range("A3", "E3");
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
                       = "Пример диаграммы";
            ObjExcel.ActiveChart.FullSeriesCollection(1).XValues = "=Лист1!$A$2:$E$2";
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
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Количество";
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
            series.Name = "Количество";
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

        private void button5_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = house1.Text;
            ObjWorkSheet.Cells[3, 2] = house2.Text;
            ObjWorkSheet.Cells[3, 3] = house3.Text;
            //ObjWorkSheet.Cells[3, 4] = "4";
            //ObjWorkSheet.Cells[3, 5] = "3";
            ObjWorkSheet.Cells[2, 1] = "За последний год";
            ObjWorkSheet.Cells[2, 2] = "За последний месяц";
            ObjWorkSheet.Cells[2, 3] = "За последнюю неделю";
            //ObjWorkSheet.Cells[2, 4] = "4";
            //ObjWorkSheet.Cells[2, 5] = "5";
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
            //

            var excelcells = ObjWorkSheet.get_Range("A3", "E3");
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
                       = "Пример диаграммы";
            ObjExcel.ActiveChart.FullSeriesCollection(1).XValues = "=Лист1!$A$2:$E$2";
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
            //((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlSeriesAxis,
            //    Excel.XlAxisGroup.xlPrimary)).HasTitle = false;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Количество";
            //Координатная сетка - оставляем только крупную сетку
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
               Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlCategory,
              Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;
            //((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlSeriesAxis,
            //  Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
            //((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlSeriesAxis,
            //  Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
              Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
              Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
            //Будем отображать легенду и уберем строки, 
            //которые отображают пустые строки таблицы
            ObjExcel.ActiveChart.HasLegend = true;
            //Расположение легенды
            ObjExcel.ActiveChart.Legend.Position
                       = Excel.XlLegendPosition.xlLegendPositionLeft;
            //Можно изменить шрифт легенды и другие параметры 
            ((Excel.LegendEntry)ObjExcel.ActiveChart.Legend.LegendEntries(1)).Font.Size = 12;
            //((Excel.LegendEntry)ObjExcel.ActiveChart.Legend.LegendEntries(3)).Font.Size = 12;
            //Легенда тесно связана с подписями на осях - изменяем надписи
            // - меняем легенду, удаляем чтото на оси - изменяется легенда
            Excel.SeriesCollection seriesCollection =
             (Excel.SeriesCollection)ObjExcel.ActiveChart.SeriesCollection(Type.Missing);
            Excel.Series series = seriesCollection.Item(1);
            series.Name = "Количество";
            //Помним, что у нас объединенные ячейки, значит каждая второя строка - пустая
            //Удаляем их из диаграммы и из легенды
            //series = seriesCollection.Item(2);
            //series.Delete();
            //После удаления второго (пустого набора значений) третий занял его место
            //series = seriesCollection.Item(2);
            series.Name = "Период";
            //series = seriesCollection.Item(3);
            //series.Delete();
            //series = seriesCollection.Item(1);

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
        
        private void button6_Click(object sender, EventArgs e)
        {
            //int[] counts = new int[3];
            //for (int i = 0; i < counts.Length; i++)
            //{
            //    List<string> count1 = SQLRequests.SelectRequest(
            //  "select sum(внесенная_сумма) from Договор where id_агент = @id",
            //  new string[] { "id" }, new string[] { (i+1).ToString() });
            //    counts[i] = Convert.ToInt32(count1[0]);
            //}
            if (counts[0] > counts[1] && counts[0] > counts[2])
            {
                if(counts[1] > counts[2])
                {
                    MessageBox.Show("Рейтинг страховых агентов: \n" +
                "1. Агент " + comboBox1.Items[0] + " (сумма договоров: " + counts[0] + ")" + 
                "\n2. Агент " + comboBox1.Items[1] + " (сумма договоров: " + counts[1] + ")" +
                "\n3. Агент " + comboBox1.Items[2] + " (сумма договоров: " + counts[2] + ")");
                }
                else
                {
                    MessageBox.Show("Рейтинг страховых агентов: \n" +
            "1. Агент " + comboBox1.Items[0] + " (сумма договоров: " + counts[0] + ")" +
            "\n2. Агент " + comboBox1.Items[2] + " (сумма договоров: " + counts[2] + ")" +
            "\n3. Агент " + comboBox1.Items[1] + " (сумма договоров: " + counts[1] + ")");
                }
            }
            else if (counts[1] > counts[0] && counts[1] > counts[2])
            {
                if(counts[0] > counts[2])
                {
                    MessageBox.Show("Рейтинг страховых агентов: \n" +
            "1. Агент " + comboBox1.Items[1] + " (сумма договоров: " + counts[1] + ")" +
            "\n2. Агент " + comboBox1.Items[0] + " (сумма договоров: " + counts[0] + ")" +
            "\n3. Агент " + comboBox1.Items[2] + " (сумма договоров: " + counts[2] + ")");
                }
                else
                {
                    MessageBox.Show("Рейтинг страховых агентов: \n" +
            "1. Агент " + comboBox1.Items[1] + " (сумма договоров: " + counts[1] + ")" +
            "\n2. Агент " + comboBox1.Items[2] + " (сумма договоров: " + counts[2] + ")" +
            "\n3. Агент " + comboBox1.Items[0] + " (сумма договоров: " + counts[0] + ")");
                }
            }
            else if (counts[2] > counts[0] && counts[2] > counts[1])
            {
                if(counts[0] > counts[1])
                {
                    MessageBox.Show("Рейтинг страховых агентов: \n" +
            "1. Агент " + comboBox1.Items[2] + " (сумма договоров: " + counts[2] + ")" +
            "\n2. Агент " + comboBox1.Items[0] + " (сумма договоров: " + counts[0] + ")" +
            "\n3. Агент " + comboBox1.Items[1] + " (сумма договоров: " + counts[1] + ")");
                }
                else
                {
                    MessageBox.Show("Рейтинг страховых агентов: \n" +
            "1. Агент " + comboBox1.Items[2] + " (сумма договоров: " + counts[2] + ")" +
            "\n2. Агент " + comboBox1.Items[1] + " (сумма договоров: " + counts[1] + ")" +
            "\n3. Агент " + comboBox1.Items[0] + " (сумма договоров: " + counts[0] + ")");
                }
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = counts[0];
            ObjWorkSheet.Cells[3, 2] = counts[1];
            ObjWorkSheet.Cells[3, 3] = counts[2];
            //ObjWorkSheet.Cells[3, 4] = "4";
            //ObjWorkSheet.Cells[3, 5] = "3";
            ObjWorkSheet.Cells[2, 1] = "Агент " + comboBox1.Items[0];
            ObjWorkSheet.Cells[2, 2] = "Агент " + comboBox1.Items[1];
            ObjWorkSheet.Cells[2, 3] = "Агент " + comboBox1.Items[2];
            //ObjWorkSheet.Cells[2, 4] = "4";
            //ObjWorkSheet.Cells[2, 5] = "5";
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
            //

            var excelcells = ObjWorkSheet.get_Range("A3", "E3");
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
                       = "Пример диаграммы";
            ObjExcel.ActiveChart.FullSeriesCollection(1).XValues = "=Лист1!$A$2:$E$2";
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
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Агент";
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Сумма открытых договоров";
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
            series.Name = "Сумма открытых договоров";
            series.Name = "Агент";

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

        private void button8_Click(object sender, EventArgs e)
        {
            int[] c1 = new int[12];
            int[] c2 = new int[12];
            GetCounts(ref c1, ref c2);

            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = c1[0];
            ObjWorkSheet.Cells[3, 2] = c1[1];
            ObjWorkSheet.Cells[3, 3] = c1[2];
            ObjWorkSheet.Cells[3, 4] = c1[3];
            ObjWorkSheet.Cells[3, 5] = c1[4];
            ObjWorkSheet.Cells[3, 6] = c1[5];
            ObjWorkSheet.Cells[3, 7] = c1[6];
            ObjWorkSheet.Cells[3, 8] = c1[7];
            ObjWorkSheet.Cells[3, 9] = c1[8];
            ObjWorkSheet.Cells[3, 10] = c1[9];
            ObjWorkSheet.Cells[3, 11] = c1[10];
            ObjWorkSheet.Cells[3, 12] = c1[11];
            //ObjWorkSheet.Cells[3, 4] = "4";
            //ObjWorkSheet.Cells[3, 5] = "3";
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
                       = "Пример диаграммы";
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
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Месяц";
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Количество договоров";
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
            series.Name = "Количество договоров";
            series.Name = "Месяц";

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

        private void button9_Click(object sender, EventArgs e)
        {
            int[] c1 = new int[12];
            int[] c2 = new int[12];
            GetCounts(ref c1, ref c2);
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = c2[0];
            ObjWorkSheet.Cells[3, 2] = c2[1];
            ObjWorkSheet.Cells[3, 3] = c2[2];
            ObjWorkSheet.Cells[3, 4] = c2[3];
            ObjWorkSheet.Cells[3, 5] = c2[4];
            ObjWorkSheet.Cells[3, 6] = c2[5];
            ObjWorkSheet.Cells[3, 7] = c2[6];
            ObjWorkSheet.Cells[3, 8] = c2[7];
            ObjWorkSheet.Cells[3, 9] = c2[8];
            ObjWorkSheet.Cells[3, 10] = c2[9];
            ObjWorkSheet.Cells[3, 11] = c2[10];
            ObjWorkSheet.Cells[3, 12] = c2[11];
            //ObjWorkSheet.Cells[3, 4] = "4";
            //ObjWorkSheet.Cells[3, 5] = "3";
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
                       = "Пример диаграммы";
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
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Месяц";
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)ObjExcel.ActiveChart.Axes(Excel.XlAxisType.xlValue,
                Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Количество договоров";
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
            series.Name = "Количество договоров";
            series.Name = "Месяц";

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
