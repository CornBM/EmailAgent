using EmailAgent.tool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAgent.model
{
    class Address
    {
        public string smtp { get; set; }
        public string pop { get; set; }
        public Address(string smtp, string pop)
        {
            this.smtp = smtp;
            this.pop = pop;
        }
    }
    public static class SMTP
    {
        private static Hashtable table = new Hashtable();

        public static void Init()
        {
            DataTable dt = new DataTable();
            dt = CSVHelper.ReadFromCSV(".\\data\\server.csv", true);
            foreach (DataRow dr in dt.Rows)
            {
                table.Add(
                    dr["domain"].ToString(),
                    new Address(
                    dr["SMTP"].ToString(),
                    dr["POP"].ToString())
                );
            }
            //获取dt中的特定信息


        }

        public static string GetSMTP(string domain)
        {
            if (table.ContainsKey(domain))
            {
                return ((Address)table[domain]).smtp.ToString();
            }
            else
            {
                return "";
            }
        }

        public static string GetPOP(string domain)
        {
            if (table.ContainsKey(domain))
            {
                return ((Address)table[domain]).pop.ToString();
            }
            else
            {
                return "";
            }
        }

    }
}
