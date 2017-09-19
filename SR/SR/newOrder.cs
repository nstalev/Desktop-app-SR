using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SR
{
    public partial class newOrder : Form
    {
        public newOrder()
        {
            InitializeComponent();

           //this.Size = new Size(1400, 1148);  
        }

        private void newOrder_Load(object sender, EventArgs e)
        {

        }
     

        private void btn_Main_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void btn_Main2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }
    }
}
