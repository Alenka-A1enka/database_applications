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
    public partial class Statistics2 : Form
    {
        public Statistics2()
        {
            InitializeComponent();
        }

        private void Statistics2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MessageBox.Show("Данные будут выгружены");
            List<string> count = SQLRequests.SelectRequest(
               "select count(*) from описание_заявки group by тип_рекламы",
               new string[] {}, new string[] { });
            int[] counts = new int[4];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = Convert.ToInt32(count[i]);
            }
            int sum = counts[0] + counts[1] + counts[2] + counts[3];
            double proc =counts[comboBox1.SelectedIndex] / sum;

            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.TypeText("\nПроцент данного типа заявок среди всех: " + proc);

        }
    }
}
