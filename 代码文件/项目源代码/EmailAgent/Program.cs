using EmailAgent.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailAgent
{
    internal static class Program
    {
        public static Form1 F;
        static void Main()
        {

            Thread thread = new Thread(() =>
            {
                SMTP.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                F = new Form1();
                Application.Run(F);
            });
            thread.SetApartmentState(ApartmentState.STA);//就是加上这段代码
            thread.Start();

            /*            string str = "=E5=\r\n=BE=AE=E8=BD=AF=E9=9B=85=E9=BB=91";
                        byte[] bytes = EmailAgent.tool.F.QP2UTF8Bytes(str);
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            Console.Write(bytes[i]+" ");
                        }
                        Console.WriteLine();
                        string s = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(s);

                        bytes = Encoding.UTF8.GetBytes("微软雅黑");
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            Console.Write(bytes[i] + " ");
                        }
            */

        }
    }
}
