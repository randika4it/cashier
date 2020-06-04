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
    public partial class FrmLogin : Form
    {
        public String username, password;
        public FrmLogin()
        {
            InitializeComponent();
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("අඩ්මින් මෙනුව වෙත පිවිසීමට අවශ්‍යද ?",
                      "Admin", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    new FrmRootLogin().Show();
                    this.Hide();
                    break;
                case DialogResult.No:

                    break;
            }
        }

        private void txtUser_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            new Form1("testing").Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            username = txtUser.Text;
            password = txtPassword.Text;
            InterfaceActivities x = new Activities();
            
            bool userStatus=x.login(username,password);
            if (userStatus == true)
            {
                new Form1(username).Show();
                this.Hide();
            }
            else
            {
                //for set Focused false
                ActiveControl = null;
                txtPassword.BorderColorIdle = Color.Red;
                txtUser.BorderColorIdle = Color.Red;
            }


        }
    }
}
