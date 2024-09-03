using EmailAgent.model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace EmailAgent.Model
{
    public class Account
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public List<EmailContent> Emails { get; set; }
        public Account(string accountName, string password)
        {
            AccountName = accountName;
            Password = password;
            Console.WriteLine("created");
            Emails = new List<EmailContent>();
        }

        private string S(string message, NetworkStream stream)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            Console.WriteLine("sending: " + message);
            stream.Write(data, 0, data.Length);

            //接收服务器返回信息
            byte[] response = new byte[1024];
            int bytes = 0;
            string serverResponse = "";

            do
            {
                bytes = stream.Read(response, 0, response.Length);
                //Console.WriteLine($"bytes: {bytes}");
                serverResponse += Encoding.UTF8.GetString(response, 0, bytes);
            } while (bytes >= 1024);

            Console.WriteLine("received: " + serverResponse);
            return serverResponse;
        }

        public void Send(EmailContent email)
        {
            //建立tcp连接
            string smtpServer = SMTP.GetSMTP(AccountName.Split('@')[1]);
            TcpClient client = new TcpClient(smtpServer, 25);
            NetworkStream stream = client.GetStream();
            //登陆
            while (!S("HELO HOST\r\n", stream).ToLower().Contains("250 ok")) { }

            S("AUTH LOGIN\r\n", stream);
            S(Convert.ToBase64String(Encoding.UTF8.GetBytes(AccountName)) + "\r\n", stream);
            Thread.Sleep(200);
            S(Convert.ToBase64String(Encoding.UTF8.GetBytes(Password)) + "\r\n", stream);

            
            List<string> messages = new List<string>
            {
                "HELO HOST\r\n",
                "MAIL FROM: <" + AccountName + ">\r\n"
            };
            foreach (string to in email.To())
            {
                messages.Add("RCPT TO: <" + to.Trim(new char[] {'<', '>'}) + ">\r\n");
            }
            messages.Add("DATA\r\n");
            messages.Add(email.Document() + "\r\n.\r\n" + "QUIT\r\n");

            foreach (string message in messages)
            {
                S(message, stream);
            }

            stream.Close();
            client.Close();

        }

        public void Receive()
        {
            List<EmailContent> emails = new List<EmailContent>();
            string serverName = AccountName.Split('@')[1];
            //建立tcp连接
            string popServer = SMTP.GetPOP(serverName);
            TcpClient client = new TcpClient(popServer, 110);
            NetworkStream stream = client.GetStream();
            //登陆
            while (S("user " + AccountName + "\r\n", stream).ToLower().Contains("+ok ")) { };
            while (S("pass " + Password + "\r\n", stream).ToLower().Contains("-err")) { };
            string ids = null;
            do
            {
                ids = S("list\r\n", stream).ToLower();
            }
            while (ids.Contains("-err"));
            string[] idList = ids.Split('\n');

            //获取邮件
            Thread t = new Thread(() =>
            {
                MessageBox.Show("连接成功，正在下载邮件！","提示",MessageBoxButtons.OK);
            });
            t.Start();
            foreach (string line in idList)
            {
                if (line.Length > 0 && line[0] >= '0' && line[0] <= '9')
                {
                    string id = line.Split(' ')[0];
                    //string id = "5";
                    

                    string message = $"retr {id}\r\n";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    EmailContent emailContent = EmailContent.GetEmailFromStream(stream, "\r\n.\r\n");
                    if (emailContent == null)
                        continue;
                    emails.Add(emailContent);

                }
                    
            }
            Console.WriteLine("receive over!");
            MessageBox.Show("邮件接收完毕！","提示", MessageBoxButtons.OK);

            Emails = emails;
        }

    }
}
