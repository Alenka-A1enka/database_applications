
namespace Страховая
{
    partial class AgentMainPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оформитьДоговорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.страховыеСлучаиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оформитьДоговорToolStripMenuItem,
            this.страховыеСлучаиToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // оформитьДоговорToolStripMenuItem
            // 
            this.оформитьДоговорToolStripMenuItem.Name = "оформитьДоговорToolStripMenuItem";
            this.оформитьДоговорToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.оформитьДоговорToolStripMenuItem.Text = "Договоры";
            this.оформитьДоговорToolStripMenuItem.Click += new System.EventHandler(this.оформитьДоговорToolStripMenuItem_Click);
            // 
            // страховыеСлучаиToolStripMenuItem
            // 
            this.страховыеСлучаиToolStripMenuItem.Name = "страховыеСлучаиToolStripMenuItem";
            this.страховыеСлучаиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.страховыеСлучаиToolStripMenuItem.Text = "Страховые случаи";
            this.страховыеСлучаиToolStripMenuItem.Click += new System.EventHandler(this.страховыеСлучаиToolStripMenuItem_Click);
            // 
            // AgentMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оформитьДоговорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem страховыеСлучаиToolStripMenuItem;
    }
}

