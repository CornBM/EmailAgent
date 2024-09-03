namespace EmailAgent
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.newMail = new System.Windows.Forms.Label();
            this.delAccount = new System.Windows.Forms.Button();
            this.receive = new System.Windows.Forms.Label();
            this.addAccount = new System.Windows.Forms.Button();
            this.accountList = new System.Windows.Forms.ListBox();
            this.midPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.openFromFile = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.leftPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.midPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightPanel, 2, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 525);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftPanel.Controls.Add(this.openFromFile);
            this.leftPanel.Controls.Add(this.newMail);
            this.leftPanel.Controls.Add(this.delAccount);
            this.leftPanel.Controls.Add(this.receive);
            this.leftPanel.Controls.Add(this.addAccount);
            this.leftPanel.Controls.Add(this.accountList);
            this.leftPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(3, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(196, 519);
            this.leftPanel.TabIndex = 0;
            // 
            // newMail
            // 
            this.newMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(108)))), ((int)(((byte)(189)))));
            this.newMail.Font = new System.Drawing.Font("华文细黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newMail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.newMail.Location = new System.Drawing.Point(7, 391);
            this.newMail.Name = "newMail";
            this.newMail.Size = new System.Drawing.Size(180, 33);
            this.newMail.TabIndex = 7;
            this.newMail.Text = "新邮件";
            this.newMail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newMail.Click += new System.EventHandler(this.newMail_Click);
            // 
            // delAccount
            // 
            this.delAccount.Location = new System.Drawing.Point(108, 124);
            this.delAccount.Name = "delAccount";
            this.delAccount.Size = new System.Drawing.Size(80, 38);
            this.delAccount.TabIndex = 6;
            this.delAccount.Text = "删除";
            this.delAccount.UseVisualStyleBackColor = true;
            this.delAccount.Click += new System.EventHandler(this.delAccount_Click);
            // 
            // receive
            // 
            this.receive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.receive.Font = new System.Drawing.Font("黑体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.receive.Location = new System.Drawing.Point(8, 201);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(180, 33);
            this.receive.TabIndex = 2;
            this.receive.Text = "收件箱刷新";
            this.receive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.receive.Click += new System.EventHandler(this.receive_Click);
            // 
            // addAccount
            // 
            this.addAccount.Location = new System.Drawing.Point(7, 123);
            this.addAccount.Name = "addAccount";
            this.addAccount.Size = new System.Drawing.Size(81, 39);
            this.addAccount.TabIndex = 1;
            this.addAccount.Text = "添加";
            this.addAccount.UseVisualStyleBackColor = true;
            this.addAccount.Click += new System.EventHandler(this.addAccount_Click);
            // 
            // accountList
            // 
            this.accountList.FormattingEnabled = true;
            this.accountList.ItemHeight = 15;
            this.accountList.Location = new System.Drawing.Point(7, 8);
            this.accountList.Name = "accountList";
            this.accountList.Size = new System.Drawing.Size(182, 109);
            this.accountList.TabIndex = 0;
            this.accountList.SelectedValueChanged += new System.EventHandler(this.accountList_SelectedValueChanged);
            // 
            // midPanel
            // 
            this.midPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.midPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.midPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.midPanel.Location = new System.Drawing.Point(205, 3);
            this.midPanel.Name = "midPanel";
            this.midPanel.Size = new System.Drawing.Size(243, 519);
            this.midPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(454, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(368, 519);
            this.rightPanel.TabIndex = 2;
            // 
            // openFromFile
            // 
            this.openFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.openFromFile.Font = new System.Drawing.Font("黑体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openFromFile.Location = new System.Drawing.Point(6, 241);
            this.openFromFile.Name = "openFromFile";
            this.openFromFile.Size = new System.Drawing.Size(180, 33);
            this.openFromFile.TabIndex = 8;
            this.openFromFile.Text = "从文件打开";
            this.openFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openFromFile.Click += new System.EventHandler(this.openFromFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(800, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel midPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label receive;
        private System.Windows.Forms.Button addAccount;
        private System.Windows.Forms.ListBox accountList;
        private System.Windows.Forms.Button delAccount;
        private System.Windows.Forms.Label newMail;
        private System.Windows.Forms.Label openFromFile;
    }
}

