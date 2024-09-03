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
using System.Windows.Forms;

namespace EmailAgent
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account a = new Account(account.Text, password.Text);
            Program.F.AddAccount(a);
            this.Hide();
        }

        private void AddAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void AddAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            account.Text = "";
            password.Text = "";
        }
    }
}
