using EmailAgent.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailAgent
{
    public partial class ReceiveEmail : UserControl
    {
        private EmailContent email;
        public ReceiveEmail(EmailContent email)
        {
            InitializeComponent();
            sender.Text = email.From();
            //获取当前时间为字符串
            
            string time = email.GetHeader("Date");
            this.time.Text = time;
            subject.Text = email.Subject();

            //获取邮件内容
            webBrowser.DocumentText = email.Html();

            this.email = email;

        }

        private void downLoad_Click(object sender, EventArgs e)
        {
            // 创建保存对话框
            SaveFileDialog saveDataSend = new SaveFileDialog();
            // Environment.SpecialFolder.MyDocuments 表示在我的文档中
            saveDataSend.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // 获取文件路径
            saveDataSend.Filter = "*.eml|eml file";   // 设置文件类型为文本文件
            saveDataSend.DefaultExt = ".eml";   // 默认文件的拓展名
            saveDataSend.FileName = $"{email.Subject()}.eml";   // 文件默认名
            saveDataSend.Title = "另存为";
            if (saveDataSend.ShowDialog() == DialogResult.OK)   // 显示文件框，并且选择文件
            {
                string fName = saveDataSend.FileName;   // 获取文件名
                                                        // 参数1：写入文件的文件名；参数2：写入文件的内容
                                                        // 字符串"Hello"是文件保存的内容，可以根据需求进行修改
                System.IO.File.WriteAllText(fName, email.Document());   // 向文件中写入内容
            }
        }
    }
}
