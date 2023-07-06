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
    public partial class DoctorPage1 : Form
    {
        public DoctorPage1()
        {
            InitializeComponent();
        }

        private void DoctorPage1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var f = new DoctorReception();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new DoctorSickLeave();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new DoctorNote();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
