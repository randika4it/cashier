using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            buns_order1.BringToFront();
        
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            beverages_order1.BringToFront();
           
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            lunch_order1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            sweets_order1.BringToFront();
        }
    }
}
