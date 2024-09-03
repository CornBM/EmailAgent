using EmailAgent.tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace EmailAgent.model
{
    //供从流中读取邮件内容的工具类
    public class Reader
    {
        //用到的流
        public Stream S { get; set; }
        //剩余的数据
        public string Left { get; set; }
        public Reader(Stream stream, string left)
        {
            S = stream;
            Left = left;
        }
    }

    //EmailContent类，用于存储邮件内容
    public class EmailContent
    {
        public Dictionary<string, string> Headers { get; set; }
        public List<EmailContent> Contents { get; set; }
        public string Data { get; set; }

        public EmailContent(Dictionary<string, string> headers, List<EmailContent> contents)
        {
            Headers = headers;
            Contents = contents;
        }

        public EmailContent(Dictionary<string, string> headers, string content)
        {
            Headers = headers;
            Data = content;
            
        }

        public EmailContent(String from, List<String> to, string subject, string content)
        {
            Headers = new Dictionary<string, string>();
            //添加From
            Headers.Add("From", from);
            //添加To
            Headers.Add("To", "");
            foreach (string recipient in to)
            {
                Headers["To"] += "<"+ recipient + ">, ";
            }
            Headers.Add("Subject", subject);
            Headers.Add("Content-Type", "text/html; charset=utf-8");

            // 截断Headers["To"]中的最后一个多余的分号和空格
            if (Headers["To"].EndsWith(", "))
            {
                Headers["To"] = Headers["To"].Substring(0, Headers["To"].Length - 2);
            }
            Data = content;
        }

        //获取指定Header的值
        public string GetHeader(string key)
        {
            string output = "";
            if (Headers.ContainsKey(key))
            {
                string temp = Headers[key];

                if (temp.StartsWith("="))
                {

                    Regex regex = new Regex(@"(?<=\?B\?)([\s\S]*?)(?=\?=)");
                    MatchCollection matches = regex.Matches(temp); // 获取所有匹配项

                    foreach (Match match in matches)
                    {
                        if (match.Success)
                        {
                            string base64Content = match.Groups[1].Value; // 捕获组中的 Base64 编码内容
                            string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(base64Content));
                            output += decodedString;
                        }
                    }

                    regex = new Regex(@"(?<=<).*?(?=>)");
                    matches = regex.Matches(temp); // 获取所有匹配项

                    foreach (Match match in matches)
                    {
                        if (match.Success)
                        {
                            string content = match.Groups[1].Value; // 捕获组中的 Base64 编码内容
                            output += content;
                        }
                    }
                }
                else
                    return temp;

                return output;
            }
            else
            {
                return output;
            }
        }

        //获取发件人
        public String From()
        {
            return GetHeader("From");
        }

        //获取收件人
        public List<String> To()
        {
            string to = GetHeader("To");
            if (to == null)
            {
                return new List<string>();
            }
            else
            {
                return new List<string>
                {
                    to
                };
            }
        }
        //获取主题
        public String Subject()
        {
            return GetHeader("Subject");
        }
        //将一个EmailContent转化为符合Mime格式的邮件内容
        public string DocumentOfContent(EmailContent content)
        {
            string output = "";
            output += F.Header2Str(content.Headers) + "\r\n";
            if (content.Contents == null)
            { 
                output += content.Data + "\r\n";
                return output;
            }
            else
            {
                string boundary = "--";
                Regex regex = new Regex("boundary=([^&]+)");
                Match match = regex.Match(content.Headers["Content-Type"]);
                bool isMultipart = content.Headers["Content-Type"].Contains("boundary");
                if (isMultipart && match.Success)
                    boundary += match.Groups[1].Value.Trim(new char[] { '"', ';' }) + "\r\n";
                else
                    boundary = "";
                foreach (EmailContent c in content.Contents)
                {
                    output += boundary;
                    output += DocumentOfContent(c);
                }
                output += boundary;
                return output;
            }
        }

        //将该EmailContent转化为符合Mime格式的邮件内容
        public String Document()
        {
            return DocumentOfContent(this);
        }

        //将EmailContent转化为Html格式供组件显示
        private string HtmlOfContent(EmailContent content, bool isPlain)
        {
            string output = "";
            if (content.Contents == null)
            {
                if (!isPlain && content.Headers["Content-Type"].ToLower().Contains("plain"))
                    return "";

                if (content.Headers.Keys.Contains("Content-Transfer-Encoding"))
                {
                    var coding = Encoding.UTF8;
                    if (content.Headers["Content-Type"].ToLower().Contains("gbk"))
                        coding = Encoding.GetEncoding("GBK");
                    switch (content.Headers["Content-Transfer-Encoding"].ToLower())
                    {
                        case "base64":
                            output += coding.GetString(Convert.FromBase64String(content.Data)) + "\r\n";
                            break;
                        case "quoted-printable":
                            output += coding.GetString(F.QP2UTF8Bytes(content.Data)) + "\r\n";
                            break;
                        default:
                            output += content.Data + "\r\n";
                            break;
                    }
                }
                else
                    output += content.Data + "\r\n";
                return output;
            }
            else
            {
                foreach (EmailContent c in content.Contents)
                {
                    output += HtmlOfContent(c, isPlain);

                }
                return output;
            }
                     
        }

        //将该EmailContent转化为Html格式供组件显示
        public string Html()
        {
            return HtmlOfContent(this, this.Headers["Content-Type"].ToLower().Contains("plain"));
        }

        //从流中获取1KB数据
        private static string Get1KB(Stream stream)
        {
            // 设置读取超时时间，例如为1000毫秒（1秒）
            bool isNetOfFile = true;
            try
            {
                stream.ReadTimeout = 200;
            }
            catch (Exception)
            {
                isNetOfFile = false;
            }

            byte[] buffer = new byte[1024];
            try
            {
                int length = stream.Read(buffer, 0, buffer.Length);
                if (!isNetOfFile && length <= 0)
                    return null;
                string sbuffer = Encoding.UTF8.GetString(buffer, 0, length);
                return sbuffer;
            }
            catch (Exception e)
            {
                // 如果发生超时异常，则返回null
                return null;
            }
        }

        //将一个content字符串拆分为2部分，以endlabel为界限
        private static string[] GetTwoPart(string content, string label)
        {
            int index = content.IndexOf(label);
            if (index == -1)
            {
                return null;
            }
            string part1 = content.Substring(0, index);
            string part2 = content.Substring(index + label.Length, content.Length - (index + label.Length));
            return new string[] { part1, part2 };
        }

        //从流中获取EmailContent
        public static EmailContent GetEmailFromStream(Stream stream, string endlabel)
        {
            return GetEmailContent(new Reader(stream, ""), endlabel);
        }

        //从流中获取EmailContent
        private static EmailContent GetEmailContent(Reader r, string endlabel)
        {
            string boundary = "";
            string[] parts = GetTwoPart(r.Left, "\r\n\r\n");

            //第一步，现将C转化为H+C(left)
            while (parts == null)
            {
                string buffer = Get1KB(r.S);
                if (buffer == null)
                {
                    return null;
                }
                r.Left += buffer;
                parts = GetTwoPart(r.Left, "\r\n\r\n");
            }
            r.Left = parts[1];

            //第二步，将H转化为字典，然后在H中看C是否是multipart
            Dictionary<string, string> dic = F.Str2Header(parts[0]);
            bool isMultipart = false;
            try
            {
                Regex regex = new Regex("boundary=([^&]+)");
                Match match = regex.Match(dic["Content-Type"]);
                isMultipart = dic["Content-Type"].Contains("boundary");
                if (isMultipart && match.Success)
                    boundary = match.Groups[1].Value.Trim(new char[] { '"', ';' });
            }
            catch (Exception e)
            {
                return null;
            }

            List<EmailContent> contents = new List<EmailContent>();
            //如果c可以继续拆分
            if (isMultipart)
            {
                while (true)
                {
                    parts = GetTwoPart(r.Left, boundary);
                    while (parts == null)
                    {
                        string temp = Get1KB(r.S);
                        /*if (temp == null)
                        {
                            return new EmailContent(dic, contents);
                        }*/
                        r.Left += temp;
                        parts = GetTwoPart(r.Left, boundary);

                    }
                    if (parts[1].Contains(endlabel))
                    {
                        Console.WriteLine("over");
                        break;
                    }
                    //如果获取了一块C
                    r.Left = parts[1];
                    EmailContent emailContent = GetEmailContent(r, boundary);
                    if (emailContent != null)
                        contents.Add(emailContent);
                    else
                        break;

                }
                return new EmailContent(dic, contents);

            }
            else
            {
                parts = GetTwoPart(r.Left, endlabel);
                while (parts == null)
                {
                    string buffer = Get1KB(r.S);
                    if (buffer == null)
                    {
                        return new EmailContent(dic, r.Left);
                    }
                    r.Left += buffer;
                    parts = GetTwoPart(r.Left, endlabel);
                }
                r.Left = endlabel + parts[1];
                return new EmailContent(dic, parts[0].Trim(new char[] { '-', ' ', '\r', '\n' }));

            }

        }
    }
}
