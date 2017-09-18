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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string password = "test";

            if (textBox1.Text == password)
            {
                this.Hide();
                var Main = new Main();
                Main.Show();
            }
            else
            {
                MessageBox.Show("Въвели сте грешна парола !" + Environment.NewLine + "Моля, въведете правилната парола и натиснете бутона 'Вход'.");
            }
        }
    }
}
