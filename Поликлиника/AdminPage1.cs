﻿using System;
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
    public partial class AdminPage1 : Form
    {
        public AdminPage1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new AdminAnalitic();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //пациенты

            var f = new AdminPatients();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //запись

            var f = new AdminNote();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void AdminPage1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Reports();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
