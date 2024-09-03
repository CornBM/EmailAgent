using EmailAgent.model;
using EmailAgent.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EmailAgent
{
    public partial class MessageList : System.Windows.Forms.UserControl
    {
        public MessageList()
        {
            InitializeComponent();
        }

        public void Flush(List<EmailContent> emails)
        {
            this.flowLayoutPanel1.Controls.Clear();
            foreach (EmailContent email in emails)
            {
                System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                panel.Height = 80;
                MessagePanel messageP = new MessagePanel(email);
                messageP.Dock = System.Windows.Forms.DockStyle.Fill;
                panel.Controls.Add(messageP);
                this.flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            foreach (System.Windows.Forms.Panel panel in this.flowLayoutPanel1.Controls)
            {
                panel.Width = this.flowLayoutPanel1.Width-30;            

            }
        }
    }
}
