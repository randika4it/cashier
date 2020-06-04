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
    public partial class Form1 : Form
    {
        String user;
        public Form1(String user)
        {
            InitializeComponent();
            this.user = user;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Menu")
                    f.Close();
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            ItemAdminPanel item = new ItemAdminPanel();
            panel2.Controls.Clear();
            item.Top = 10;
            item.Left = 10;
            panel2.Controls.Add(item);
            Console.WriteLine("panel called");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUser.Text = user;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ඔබට ඉඅවත්වීමට අවශ්‍යද ?",
                      "Admin", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    new FrmLogin().Show();
                    this.Hide();
                    break;
                case DialogResult.No:

                    break;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            OrderView item = new OrderView();
            panel2.Controls.Clear();
            item.Top = 10;
            item.Left = 10;
            panel2.Controls.Add(item);
        }
    }
}
