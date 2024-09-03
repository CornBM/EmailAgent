using EmailAgent.model;
using EmailAgent.Model;
using EmailAgent.tool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmailAgent
{
    public partial class Form1 : Form
    {
        public Account currentAccount;
        public Hashtable accounts;
        public MessageList currentMessageList;

        public AddAccount addAccountWindow;
        public Form1()
        {
            InitializeComponent();
            LoadAccounts();
            currentMessageList = new MessageList();
            midPanel.Controls.Add(currentMessageList);
            currentMessageList.Dock = DockStyle.Fill;

            addAccountWindow = new AddAccount();
            addAccountWindow.Visible = false;

        }

        public void LoadAccounts()
        {
            accounts = new Hashtable();
            DataTable dt = CSVHelper.ReadFromCSV(".\\data\\accounts.csv", true);
            foreach (DataRow dr in dt.Rows)
            {
                Account account = new Account(dr["account"].ToString(), dr["password"].ToString());
                AddAccount(account);
            }
        }

        public void SaveAccounts()
        {
            using (StreamWriter sw = new StreamWriter(".\\data\\accounts.csv"))
            {
                sw.WriteLine("account,password");
                foreach(var key in accounts.Keys)
                {
                    Account account = (Account)accounts[(string)key];
                    sw.WriteLine($"{account.AccountName},{account.Password}");
                }
            }
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account.AccountName, account);
            accountList.Items.Add(account.AccountName);
        }

        public void RemoveAccount(string accountName)
        {
            try
            {
                accounts.Remove(accountName);
                accountList.Items.Remove(accountName);
            }
            catch { }
        }

        public void ChangeRightPanel(Control control)
        {
            try
            {
                rightPanel.Controls.Clear();
                rightPanel.Controls.Add(control);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FlushMidPanel()
        {
            currentMessageList.Flush(currentAccount.Emails);
        }

        public void ReadEmail(EmailContent email)
        {
            ReceiveEmail receiveEmail = new ReceiveEmail(email);
            receiveEmail.Dock = DockStyle.Fill;
            ChangeRightPanel(receiveEmail);
        }
        private void accountList_SelectedValueChanged(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
            currentAccount = (Account)accounts[accountList.SelectedItem.ToString()];
            currentMessageList.Flush(currentAccount.Emails);
            Console.WriteLine(currentAccount.AccountName);
        }

        private void newMail_Click(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
            SendEmail sendEmail = new SendEmail(currentAccount);
            sendEmail.Dock = DockStyle.Fill;
            rightPanel.Controls.Add(sendEmail);
        }

        private void receive_Click(object sender, EventArgs e)
        {
            currentAccount.Receive();
            FlushMidPanel();
        }

        private void addAccount_Click(object sender, EventArgs e)
        {
            addAccountWindow.Location = this.Location;
            addAccountWindow.Visible = true;
        }

        private void delAccount_Click(object sender, EventArgs e)
        {
            RemoveAccount(currentAccount.AccountName);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAccounts();
        }

        private void openFromFile_Click(object sender, EventArgs e)
        {
            // 创建OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "打开";
            openFileDialog.Filter = "eml文件(*.eml)|*.eml";
            DialogResult result = openFileDialog.ShowDialog();

            // 如果用户选择了文件并点击了"打开"按钮
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName; 
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                EmailContent email = EmailContent.GetEmailFromStream(stream, "\r\n.\r\n");
                ReceiveEmail receiveEmail = new ReceiveEmail(email);
                receiveEmail.Dock = DockStyle.Fill;
                ChangeRightPanel(receiveEmail);
            }
           
        }
    }
}
