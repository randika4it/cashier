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
    public partial class frmKitchen : Form
    {
        public frmKitchen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addItem("ffw", "ewfwe", "ewfew");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int poss = 40;
        public void addItem(String name, String size, String qty)
        {
            Console.WriteLine("kitchen called " + name + size + qty);
            KitchenOrders item = new KitchenOrders(name, size, qty);
            panel2.Controls.Add(item);
            item.Top = poss;
            item.Left = 20;
            poss = (item.Top + item.Height + 10);
        }

       

        private void frmKitchen_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
