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

            MessageBox.Show("Това накрая ще го правим");
        }

        private void btn_createWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createWorker = new createWorker();
            createWorker.Show();
        }

        private void btn_deleteWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            var deleteWorker = new deleteWorker();
            deleteWorker.Show();
        }
    }
}
