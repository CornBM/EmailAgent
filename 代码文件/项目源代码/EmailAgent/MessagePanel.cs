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
    public partial class MessagePanel : UserControl
    {
        public EmailContent email;
        public MessagePanel(EmailContent email)
        {
            InitializeComponent();
            this.email = email;
            this.subject.Text = email.Subject();
            this.sender.Text = email.From();
            this.datetime.Text = "";
        }


        private void subject_Click(object sender, EventArgs e)
        {
            Program.F.ReadEmail(email);
        }


    }
}
