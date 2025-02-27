namespace AppBox.WdUtilites
{
    partial class ConnectDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listViewWinUsers = new System.Windows.Forms.ListView();
            this.listViewOrg = new System.Windows.Forms.ListView();
            this.listViewConn = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxConnStr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(632, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(713, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listViewWinUsers
            // 
            this.listViewWinUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewWinUsers.HideSelection = false;
            this.listViewWinUsers.Location = new System.Drawing.Point(0, 0);
            this.listViewWinUsers.Name = "listViewWinUsers";
            this.listViewWinUsers.Size = new System.Drawing.Size(258, 397);
            this.listViewWinUsers.TabIndex = 2;
            this.listViewWinUsers.UseCompatibleStateImageBehavior = false;
            this.listViewWinUsers.View = System.Windows.Forms.View.List;
            this.listViewWinUsers.SelectedIndexChanged += new System.EventHandler(this.listViewWinUsers_SelectedIndexChanged);
            // 
            // listViewOrg
            // 
            this.listViewOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOrg.HideSelection = false;
            this.listViewOrg.Location = new System.Drawing.Point(0, 0);
            this.listViewOrg.Name = "listViewOrg";
            this.listViewOrg.Size = new System.Drawing.Size(235, 397);
            this.listViewOrg.TabIndex = 3;
            this.listViewOrg.UseCompatibleStateImageBehavior = false;
            this.listViewOrg.View = System.Windows.Forms.View.List;
            this.listViewOrg.SelectedIndexChanged += new System.EventHandler(this.listViewOrg_SelectedIndexChanged);
            // 
            // listViewConn
            // 
            this.listViewConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewConn.HideSelection = false;
            this.listViewConn.Location = new System.Drawing.Point(0, 0);
            this.listViewConn.Name = "listViewConn";
            this.listViewConn.Size = new System.Drawing.Size(275, 397);
            this.listViewConn.TabIndex = 4;
            this.listViewConn.UseCompatibleStateImageBehavior = false;
            this.listViewConn.View = System.Windows.Forms.View.List;
            this.listViewConn.SelectedIndexChanged += new System.EventHandler(this.listViewConn_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewWinUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(776, 397);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewOrg);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewConn);
            this.splitContainer2.Size = new System.Drawing.Size(514, 397);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBoxConnStr
            // 
            this.textBoxConnStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxConnStr.Location = new System.Drawing.Point(12, 418);
            this.textBoxConnStr.Name = "textBoxConnStr";
            this.textBoxConnStr.ReadOnly = true;
            this.textBoxConnStr.Size = new System.Drawing.Size(614, 20);
            this.textBoxConnStr.TabIndex = 6;
            // 
            // ConnectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxConnStr);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ConnectDialog";
            this.Text = "ConnectDialog";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listViewWinUsers;
        private System.Windows.Forms.ListView listViewOrg;
        private System.Windows.Forms.ListView listViewConn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBoxConnStr;
    }
}