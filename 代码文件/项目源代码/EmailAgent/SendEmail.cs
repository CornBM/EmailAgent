using EmailAgent.model;
using EmailAgent.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using System.IO;
using System.Net.Http;

namespace EmailAgent
{
    public partial class SendEmail : UserControl
    {
        private Account account;
        private Control content;
        public SendEmail(Account account)
        {
            InitializeComponent();
            this.account = account;

            this.comboBox.Items.Add("RTF富文本");
            this.comboBox.Items.Add("HTML邮件");
            this.comboBox.SelectedValue = "RTF富文本";
            this.OpenFile.Enabled = false;
        }

        public string GetHtmlContent()
        {
            switch (this.comboBox.SelectedItem.ToString())
            {
                case "RTF富文本":
                    string content = ((RichTextBox)this.content).Rtf;

                    // 使用 MemoryStream 作为保存目标
                    MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
                    // 创建 Document 对象
                    Document document = new Document();
                    // 使用 RTF 内容加载文档
                    document.LoadFromStream(memoryStream, FileFormat.Rtf);
                    MemoryStream memoryStream2 = new MemoryStream();
                    document.SaveToStream(memoryStream2, FileFormat.Html);
                    // 清理 MemoryStream 资源
                    memoryStream.Dispose();
                    memoryStream2.Dispose();

                    // 将 MemoryStream 转换为字符串
                    return Encoding.UTF8.GetString(memoryStream2.ToArray());
                case "HTML邮件":
                    return ((WebBrowser)this.content).DocumentText;
            }
            return "";
        }

        public EmailContent GetEmail()
        {
            List<string> to = new List<string>();
            to.Add(this.receiver.Text);
            
            string subject = this.subject.Text;

            string htmlContent = GetHtmlContent();
            return new EmailContent(account.AccountName,to, subject, htmlContent);
        }   

        public void ChangeEditPanel(Control control)
        {
            this.content = control;
            control.Dock = DockStyle.Fill;
            this.editPanel.Controls.Clear();
            this.editPanel.Controls.Add(control);
        }

        private void send_Click(object sender, EventArgs e)
        {
            EmailContent email = GetEmail();
            //Console.WriteLine(email.Content);
            account.Send(email);
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            // 创建一个OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择HTML文件"; // 对话框标题
            openFileDialog.Filter = "HTML文件 (*.html)|*.html"; // 只显示HTML文件
            openFileDialog.FilterIndex = 1; // 默认过滤条件
            openFileDialog.RestoreDirectory = true; // 记住上次打开的目录

            // 显示文件选择对话框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的文件路径
                string filePath = openFileDialog.FileName;

                // 读取文件内容
                try
                {
                    ((WebBrowser)this.content).DocumentText = File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取文件时出错: " + ex.Message);
                }
            }
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (this.comboBox.SelectedItem.ToString())
            {
                case "RTF富文本":
                    this.OpenFile.Enabled = false;
                    ChangeEditPanel(new RichTextBox());
                    break;
                case "HTML邮件":
                    this.OpenFile.Enabled = true;
                    ChangeEditPanel(new WebBrowser());
                    break;
            }
        }
    }
}
