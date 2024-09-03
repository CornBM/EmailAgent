namespace EmailAgent
{
    partial class MessagePanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sender = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.Label();
            this.datetime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sender, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.subject, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.datetime, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 101);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sender
            // 
            this.sender.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.sender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sender.Font = new System.Drawing.Font("黑体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sender.Location = new System.Drawing.Point(3, 0);
            this.sender.Name = "sender";
            this.sender.Size = new System.Drawing.Size(197, 36);
            this.sender.TabIndex = 0;
            this.sender.Text = "label1";
            this.sender.Click += new System.EventHandler(this.subject_Click);
            // 
            // subject
            // 
            this.subject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subject.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.subject.Location = new System.Drawing.Point(3, 36);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(197, 36);
            this.subject.TabIndex = 1;
            this.subject.Text = "label2";
            this.subject.Click += new System.EventHandler(this.subject_Click);
            // 
            // datetime
            // 
            this.datetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetime.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datetime.Location = new System.Drawing.Point(3, 72);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(197, 29);
            this.datetime.TabIndex = 2;
            this.datetime.Text = "label3";
            this.datetime.Click += new System.EventHandler(this.subject_Click);
            // 
            // MessagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MessagePanel";
            this.Size = new System.Drawing.Size(203, 101);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label sender;
        private System.Windows.Forms.Label subject;
        private System.Windows.Forms.Label datetime;
    }
}
