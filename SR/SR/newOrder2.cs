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
    public partial class newOrder2 : Form
    {
        public newOrder2()
        {
            InitializeComponent();

            comboBox1.Items.Add("Да");
            comboBox1.Items.Add("Не");

            comboBox2.Items.Add("Да");
            comboBox2.Items.Add("Не");

            comboBox3.Items.Add("Иван");
            comboBox3.Items.Add("Драган");
            comboBox3.Items.Add("Петкан");

            comboBox4.Items.Add("Иван");
            comboBox4.Items.Add("Драган");
            comboBox4.Items.Add("Петкан");
        }

        private void btn_backPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newOrder = new newOrder();
            newOrder.Show();
        }

        private void btn_nextPage2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newOrder3 = new newOrder3();
            newOrder3.Show();
        }
    }
}
