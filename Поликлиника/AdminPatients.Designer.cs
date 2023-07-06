
namespace Поликлиника
{
    partial class AdminPatients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lastname = new System.Windows.Forms.TextBox();
            this.lb4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.birthday = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pas2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pas1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.middle_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.last_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.lastname);
            this.tabPage1.Controls.Add(this.lb4);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Результаты анализов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Результаты анализов пациента за последний месяц: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(38, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 44);
            this.button1.TabIndex = 24;
            this.button1.Text = "Показать результаты";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(335, 39);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(343, 28);
            this.lastname.TabIndex = 23;
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb4.ForeColor = System.Drawing.Color.White;
            this.lb4.Location = new System.Drawing.Point(34, 39);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(276, 24);
            this.lb4.TabIndex = 22;
            this.lb4.Text = "Введите фамилию пациента: ";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.birthday);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.address);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.pol);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.pas2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.pas1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.middle_name);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.name);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.last_name);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Добавить амбулаторную карту";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(36, 575);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(342, 46);
            this.button2.TabIndex = 42;
            this.button2.Text = "Добавить карту пациента";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(715, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 336);
            this.label11.TabIndex = 41;
            this.label11.Text = "00\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n0";
            // 
            // birthday
            // 
            this.birthday.Location = new System.Drawing.Point(36, 491);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(277, 28);
            this.birthday.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(32, 454);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(346, 24);
            this.label10.TabIndex = 39;
            this.label10.Text = "Дата рождения (формат: dd.mm.yyyy)";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(36, 391);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(277, 28);
            this.address.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(32, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "Адрес";
            // 
            // pol
            // 
            this.pol.Location = new System.Drawing.Point(433, 293);
            this.pol.Name = "pol";
            this.pol.Size = new System.Drawing.Size(277, 28);
            this.pol.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(429, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 24);
            this.label8.TabIndex = 35;
            this.label8.Text = "Номер страхового полиса";
            // 
            // pas2
            // 
            this.pas2.Location = new System.Drawing.Point(433, 204);
            this.pas2.Name = "pas2";
            this.pas2.Size = new System.Drawing.Size(277, 28);
            this.pas2.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(429, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Номер паспорта";
            // 
            // pas1
            // 
            this.pas1.Location = new System.Drawing.Point(433, 119);
            this.pas1.Name = "pas1";
            this.pas1.Size = new System.Drawing.Size(277, 28);
            this.pas1.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(429, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 24);
            this.label6.TabIndex = 31;
            this.label6.Text = "Серия паспорта";
            // 
            // middle_name
            // 
            this.middle_name.Location = new System.Drawing.Point(36, 293);
            this.middle_name.Name = "middle_name";
            this.middle_name.Size = new System.Drawing.Size(277, 28);
            this.middle_name.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(32, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 24);
            this.label5.TabIndex = 29;
            this.label5.Text = "Отчество";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(36, 204);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(277, 28);
            this.name.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(32, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Заполните данные пациента: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(32, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Имя";
            // 
            // last_name
            // 
            this.last_name.Location = new System.Drawing.Point(36, 119);
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(277, 28);
            this.last_name.TabIndex = 25;
            this.last_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Фамилия";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AdminPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminPatients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AdminPatients_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.TextBox last_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox birthday;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox pas2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pas1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox middle_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox name;
    }
}