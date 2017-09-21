using MySql.Data.MySqlClient;
using SR.Service;
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
    public partial class allOrders : Form
    {
        private OrderService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';";
        public allOrders()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
        }

        private void btn_Main3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }
    }
}
