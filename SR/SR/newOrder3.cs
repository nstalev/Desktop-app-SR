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
    public partial class newOrder3 : Form
    {
        public newOrder3()
        {
            InitializeComponent();
        }

        private void btn_backPage2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newOrder2 = new newOrder2();
            newOrder2.Show();
        }

        private void btn_nextPage3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newOrder4 = new newOrder4();
            newOrder4.Show();
        }
    }
}
