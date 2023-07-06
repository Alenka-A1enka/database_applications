
namespace Рекламное_агентство
{
    partial class AgentMainPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новыеЗаявкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заявкиНаВыполненииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завершенныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отклоненныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(194, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Клиенты";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыеЗаявкиToolStripMenuItem,
            this.заявкиНаВыполненииToolStripMenuItem,
            this.завершенныеToolStripMenuItem,
            this.отклоненныеToolStripMenuItem,
            this.статистикаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(157, 450);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новыеЗаявкиToolStripMenuItem
            // 
            this.новыеЗаявкиToolStripMenuItem.Name = "новыеЗаявкиToolStripMenuItem";
            this.новыеЗаявкиToolStripMenuItem.Size = new System.Drawing.Size(142, 27);
            this.новыеЗаявкиToolStripMenuItem.Text = "Новые заявки";
            this.новыеЗаявкиToolStripMenuItem.Click += new System.EventHandler(this.новыеЗаявкиToolStripMenuItem_Click);
            // 
            // заявкиНаВыполненииToolStripMenuItem
            // 
            this.заявкиНаВыполненииToolStripMenuItem.Name = "заявкиНаВыполненииToolStripMenuItem";
            this.заявкиНаВыполненииToolStripMenuItem.Size = new System.Drawing.Size(142, 27);
            this.заявкиНаВыполненииToolStripMenuItem.Text = "На выполнении";
            this.заявкиНаВыполненииToolStripMenuItem.Click += new System.EventHandler(this.заявкиНаВыполненииToolStripMenuItem_Click);
            // 
            // завершенныеToolStripMenuItem
            // 
            this.завершенныеToolStripMenuItem.Name = "завершенныеToolStripMenuItem";
            this.завершенныеToolStripMenuItem.Size = new System.Drawing.Size(142, 27);
            this.завершенныеToolStripMenuItem.Text = "Завершенные";
            this.завершенныеToolStripMenuItem.Click += new System.EventHandler(this.завершенныеToolStripMenuItem_Click);
            // 
            // отклоненныеToolStripMenuItem
            // 
            this.отклоненныеToolStripMenuItem.Name = "отклоненныеToolStripMenuItem";
            this.отклоненныеToolStripMenuItem.Size = new System.Drawing.Size(142, 27);
            this.отклоненныеToolStripMenuItem.Text = "Отклоненные";
            this.отклоненныеToolStripMenuItem.Click += new System.EventHandler(this.отклоненныеToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(142, 27);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            this.статистикаToolStripMenuItem.Click += new System.EventHandler(this.статистикаToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(194, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пока у вас нет клиентов";
            // 
            // AgentMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AgentMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AgentMainPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новыеЗаявкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заявкиНаВыполненииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завершенныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отклоненныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}