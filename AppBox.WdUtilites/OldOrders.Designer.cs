namespace AppBox.WdUtilites
{
    partial class OldOrders
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
            this.cBoxDockOper = new System.Windows.Forms.ComboBox();
            this.cBoxDockState = new System.Windows.Forms.ComboBox();
            this.listViewOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtStop = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxModelPic = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxRemove = new System.Windows.Forms.CheckBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBoxDockOper
            // 
            this.cBoxDockOper.FormattingEnabled = true;
            this.cBoxDockOper.Location = new System.Drawing.Point(12, 33);
            this.cBoxDockOper.Name = "cBoxDockOper";
            this.cBoxDockOper.Size = new System.Drawing.Size(192, 21);
            this.cBoxDockOper.TabIndex = 0;
            // 
            // cBoxDockState
            // 
            this.cBoxDockState.FormattingEnabled = true;
            this.cBoxDockState.Location = new System.Drawing.Point(12, 70);
            this.cBoxDockState.Name = "cBoxDockState";
            this.cBoxDockState.Size = new System.Drawing.Size(192, 21);
            this.cBoxDockState.TabIndex = 1;
            // 
            // listViewOrders
            // 
            this.listViewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewOrders.HideSelection = false;
            this.listViewOrders.Location = new System.Drawing.Point(12, 138);
            this.listViewOrders.Name = "listViewOrders";
            this.listViewOrders.Size = new System.Drawing.Size(500, 300);
            this.listViewOrders.TabIndex = 2;
            this.listViewOrders.UseCompatibleStateImageBehavior = false;
            this.listViewOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Номер";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Контрагент";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата";
            // 
            // dtStop
            // 
            this.dtStop.Location = new System.Drawing.Point(253, 71);
            this.dtStop.Name = "dtStop";
            this.dtStop.Size = new System.Drawing.Size(200, 20);
            this.dtStop.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Запустить очистку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(529, 164);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(259, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // checkBoxModelPic
            // 
            this.checkBoxModelPic.AutoSize = true;
            this.checkBoxModelPic.Location = new System.Drawing.Point(531, 48);
            this.checkBoxModelPic.Name = "checkBoxModelPic";
            this.checkBoxModelPic.Size = new System.Drawing.Size(71, 17);
            this.checkBoxModelPic.TabIndex = 7;
            this.checkBoxModelPic.Text = "Чертежи";
            this.checkBoxModelPic.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(531, 71);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Материалы";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBoxRemove
            // 
            this.checkBoxRemove.AutoSize = true;
            this.checkBoxRemove.Location = new System.Drawing.Point(531, 94);
            this.checkBoxRemove.Name = "checkBoxRemove";
            this.checkBoxRemove.Size = new System.Drawing.Size(127, 17);
            this.checkBoxRemove.TabIndex = 9;
            this.checkBoxRemove.Text = "Удалить полностью";
            this.checkBoxRemove.UseVisualStyleBackColor = true;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(253, 33);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Тип документа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Статус документа";
            // 
            // OldOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.checkBoxRemove);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBoxModelPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtStop);
            this.Controls.Add(this.listViewOrders);
            this.Controls.Add(this.cBoxDockState);
            this.Controls.Add(this.cBoxDockOper);
            this.Name = "OldOrders";
            this.Text = "OldOrders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxDockOper;
        private System.Windows.Forms.ComboBox cBoxDockState;
        private System.Windows.Forms.ListView listViewOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.DateTimePicker dtStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxModelPic;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBoxRemove;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}