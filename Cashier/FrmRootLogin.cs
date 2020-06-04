using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class FrmRootLogin : Form
    {
        String username,password;
        public FrmRootLogin()
        {
            InitializeComponent();
        }

        private void FrmRootLogin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            username = txtUser.Text;
            password = txtPassword.Text;
            InterfaceActivities x = new Activities();

            bool userStatus = x.loginAdmin(username, password);
            if (userStatus == true)
            {
                new Form1(username).Show();
                this.Hide();
            }
            else
            {
                //for set Focused false
                ActiveControl = null;
                lblError.ForeColor = Color.Red;
                lblError.Text = "සමාවන්න ඔබට මේ සදහා අවසර නොමැත ";

                txtPassword.BorderColorIdle = Color.Red;
                txtUser.BorderColorIdle = Color.Red;

            }
        }
    }
}
