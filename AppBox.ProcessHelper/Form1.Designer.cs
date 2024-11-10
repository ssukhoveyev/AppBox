namespace AppBox.ProcessHelper
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отфильтроватьПоПользователюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьФильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem,
            this.отфильтроватьПоПользователюToolStripMenuItem,
            this.удалитьФильтрToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(289, 70);
            // 
            // отфильтроватьПоНазваниюПроцессаToolStripMenuItem
            // 
            this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem.Name = "отфильтроватьПоНазваниюПроцессаToolStripMenuItem";
            this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem.Text = "Отфильтровать по названию процесса";
            this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem.Click += new System.EventHandler(this.отфильтроватьПоНазваниюПроцессаToolStripMenuItem_Click);
            // 
            // отфильтроватьПоПользователюToolStripMenuItem
            // 
            this.отфильтроватьПоПользователюToolStripMenuItem.Name = "отфильтроватьПоПользователюToolStripMenuItem";
            this.отфильтроватьПоПользователюToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.отфильтроватьПоПользователюToolStripMenuItem.Text = "Отфильтровать по пользователю";
            this.отфильтроватьПоПользователюToolStripMenuItem.Click += new System.EventHandler(this.отфильтроватьПоПользователюToolStripMenuItem_Click);
            // 
            // удалитьФильтрToolStripMenuItem
            // 
            this.удалитьФильтрToolStripMenuItem.Name = "удалитьФильтрToolStripMenuItem";
            this.удалитьФильтрToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.удалитьФильтрToolStripMenuItem.Text = "Удалить фильтр";
            this.удалитьФильтрToolStripMenuItem.Click += new System.EventHandler(this.удалитьФильтрToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отфильтроватьПоНазваниюПроцессаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отфильтроватьПоПользователюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьФильтрToolStripMenuItem;
    }
}

