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
    public partial class ItemAdminPanel : UserControl
    {
        String activity, itemCode;
        public ItemAdminPanel()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            activity = "update";
            itemCode = new Activities().getNextItemCode();
            ItemOptions item = new ItemOptions(activity, itemCode);
            panel1.Controls.Clear();
            item.Top = 10;
            item.Left = 10;
            panel1.Controls.Add(item);

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            activity = "delete";
            itemCode = new Activities().getNextItemCode();
            ItemOptions item = new ItemOptions(activity, itemCode);
            panel1.Controls.Clear();
            item.Top = 10;
            item.Left = 10;
            panel1.Controls.Add(item);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            activity = "add";
            itemCode=new Activities().getNextItemCode();
            ItemOptions1 item = new ItemOptions1(activity,itemCode);
            panel1.Controls.Clear();
            item.Top = 10;
            item.Left = 10;
            panel1.Controls.Add(item);
            
           
        }
    }
}
