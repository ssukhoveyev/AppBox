namespace AppBox.CopyFileApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSourceDir = new System.Windows.Forms.TextBox();
            this.textBoxTargetlDir = new System.Windows.Forms.TextBox();
            this.butSourceDir = new System.Windows.Forms.Button();
            this.butTargetDir = new System.Windows.Forms.Button();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDelFile = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem1.Text = "Выход";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // textBoxSourceDir
            // 
            this.textBoxSourceDir.Location = new System.Drawing.Point(12, 63);
            this.textBoxSourceDir.Name = "textBoxSourceDir";
            this.textBoxSourceDir.Size = new System.Drawing.Size(601, 20);
            this.textBoxSourceDir.TabIndex = 1;
            // 
            // textBoxTargetlDir
            // 
            this.textBoxTargetlDir.Location = new System.Drawing.Point(12, 105);
            this.textBoxTargetlDir.Name = "textBoxTargetlDir";
            this.textBoxTargetlDir.Size = new System.Drawing.Size(601, 20);
            this.textBoxTargetlDir.TabIndex = 2;
            // 
            // butSourceDir
            // 
            this.butSourceDir.Location = new System.Drawing.Point(629, 61);
            this.butSourceDir.Name = "butSourceDir";
            this.butSourceDir.Size = new System.Drawing.Size(86, 23);
            this.butSourceDir.TabIndex = 3;
            this.butSourceDir.Text = "butSourceDir";
            this.butSourceDir.UseVisualStyleBackColor = true;
            this.butSourceDir.Click += new System.EventHandler(this.butSourceDir_Click);
            // 
            // butTargetDir
            // 
            this.butTargetDir.Location = new System.Drawing.Point(629, 103);
            this.butTargetDir.Name = "butTargetDir";
            this.butTargetDir.Size = new System.Drawing.Size(86, 23);
            this.butTargetDir.TabIndex = 4;
            this.butTargetDir.Text = "butTargetDir";
            this.butTargetDir.UseVisualStyleBackColor = true;
            this.butTargetDir.Click += new System.EventHandler(this.butTargetDir_Click);
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "5 сек",
            "15 сек",
            "30 сек",
            "1 мин",
            "5 мин",
            "15 мин"});
            this.comboBoxInterval.Location = new System.Drawing.Point(12, 181);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInterval.TabIndex = 5;
            this.comboBoxInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterval_SelectedIndexChanged);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 217);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(703, 154);
            this.textBoxLog.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(149, 183);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(217, 17);
            this.checkBoxAutoStart.TabIndex = 8;
            this.checkBoxAutoStart.Text = "Автоматически запускать при старте";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.checkBoxAutoStart_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Откуда копировать";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Куда копировать";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Интервал";
            // 
            // checkBoxDelFile
            // 
            this.checkBoxDelFile.AutoSize = true;
            this.checkBoxDelFile.Location = new System.Drawing.Point(15, 131);
            this.checkBoxDelFile.Name = "checkBoxDelFile";
            this.checkBoxDelFile.Size = new System.Drawing.Size(158, 17);
            this.checkBoxDelFile.TabIndex = 12;
            this.checkBoxDelFile.Text = "Удалять исходные файлы";
            this.checkBoxDelFile.UseVisualStyleBackColor = true;
            this.checkBoxDelFile.CheckedChanged += new System.EventHandler(this.checkBoxDelFile_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(109, 29);
            this.buttonStart.TabIndex = 13;
            this.buttonStart.Text = "ПУСК";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkBoxDelFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.butTargetDir);
            this.Controls.Add(this.butSourceDir);
            this.Controls.Add(this.textBoxTargetlDir);
            this.Controls.Add(this.textBoxSourceDir);
            this.Name = "Form1";
            this.Text = "Копирование файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox textBoxSourceDir;
        private System.Windows.Forms.TextBox textBoxTargetlDir;
        private System.Windows.Forms.Button butSourceDir;
        private System.Windows.Forms.Button butTargetDir;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDelFile;
        private System.Windows.Forms.Button buttonStart;
    }
}

