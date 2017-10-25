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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void newOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newOrder = new newOrder();
            newOrder.Show();
        }


        private void allOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            var allOrders = new allOrders();
            allOrders.Show();
        }

        private void calcHours_Click(object sender, EventArgs e)
        {
            this.Hide();
            var calcHours = new calcHours();
            calcHours.Show();
        }

        private void btn_manageWorkers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var allWorkers = new allWorkers();
            allWorkers.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите програмата ?", "Затваряне на програмата.", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
