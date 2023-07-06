using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Страховая
{
    public partial class AgentMainPage : Form
    {
        public AgentMainPage()
        {
            InitializeComponent();
        }

        private void оформитьДоговорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ContractForm();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void страховыеСлучаиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var f = new InsuranceCase();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void AgentMainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
