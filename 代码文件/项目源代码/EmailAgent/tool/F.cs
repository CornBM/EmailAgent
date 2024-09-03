using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmailAgent.tool
{
    public static class F
    {
        public static string Header2Str(Dictionary<string, string> headers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in headers.Keys)
            {
                sb.AppendLine(key + ": " + headers[key]);
            }
            return sb.ToString();
        }

        public static Dictionary<string, string> Str2Header(string header)
        {
            string[] lines = header.Split('\n');
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string currentKey = "";
            foreach (string line in lines)
            {
                string[] data = line.Split(':');
                if (dic.Keys.Contains(data[0].Trim()))
                    continue;
                if (data.Length == 2) {
                    currentKey = data[0].Trim();
                    dic.Add(data[0].Trim(), data[1].Trim());
                }
                else if(data.Length < 2 && currentKey != "")
                {
                    dic[currentKey] += data[0].Trim(new char[] { '\r', '\n', ' ' });
                }

            }
            return dic;
        }

        public static byte[] QP2UTF8Bytes(string data)
        {
            // 遍历每一个字符
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < data.Length; i++)
            {
                // 如果是=开头的，则说明是编码字符，需要解码
                if (data[i] == '=')
                {
                    try
                    {
                        if (isHex(data[i + 1]) && isHex(data[i + 2]))
                        {
                            // 取出后面两个字符，并转换成16进制
                            string hex = data.Substring(i + 1, 2);
                            int value = Convert.ToByte(hex, 16);
                            // 追加到字节数组  
                            bytes.Add((byte)value);
                        }
                        i += 2;
                    }
                    catch
                    {
                        continue;
                    }
                }
                else
                {
                    bytes.Add((byte)data[i]);
                }
            }
            return bytes.ToArray();
            
        }

        private static bool isHex(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
        }
    }
 }

