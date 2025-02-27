namespace AppBox.WdUtilites
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обслуживаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.старыеЗаказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 789);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1385, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базаДанныхToolStripMenuItem,
            this.обслуживаниеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1385, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключениеToolStripMenuItem});
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // подключениеToolStripMenuItem
            // 
            this.подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
            this.подключениеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.подключениеToolStripMenuItem.Text = "Подключение";
            this.подключениеToolStripMenuItem.Click += new System.EventHandler(this.подключениеToolStripMenuItem_Click);
            // 
            // обслуживаниеToolStripMenuItem
            // 
            this.обслуживаниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.старыеЗаказыToolStripMenuItem});
            this.обслуживаниеToolStripMenuItem.Name = "обслуживаниеToolStripMenuItem";
            this.обслуживаниеToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.обслуживаниеToolStripMenuItem.Text = "Обслуживание БД";
            // 
            // старыеЗаказыToolStripMenuItem
            // 
            this.старыеЗаказыToolStripMenuItem.Name = "старыеЗаказыToolStripMenuItem";
            this.старыеЗаказыToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.старыеЗаказыToolStripMenuItem.Text = "Старые заказы";
            this.старыеЗаказыToolStripMenuItem.Click += new System.EventHandler(this.старыеЗаказыToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 811);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem обслуживаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem старыеЗаказыToolStripMenuItem;
    }
}

