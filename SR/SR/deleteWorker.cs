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
    public partial class deleteWorker : Form
    {
        public deleteWorker()
        {
            InitializeComponent();

            comboBox1.Items.Add("Иван");
            comboBox1.Items.Add("Драган");
            comboBox1.Items.Add("Петкан");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_Main5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }
    }
}
