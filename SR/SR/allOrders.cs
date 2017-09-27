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

        public static string numberOrder;
        public allOrders()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
            ShowAllOrders();
        }

        private void btn_Main3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void ShowAllOrders()
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();

            string selectAllOrders = service.GetAllOrders();

            MySqlCommand command = new MySqlCommand(selectAllOrders, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            connection.Close();
        }


        //------------SHOULD BE UPDATED---------
        private void btn_search_Click(object sender, EventArgs e)
        {
            string orderNumber = textBox5.Text;
            int orderNumtoInt = 0;

            if (String.IsNullOrEmpty(orderNumber))
            {
                MessageBox.Show("Моля изберете номер на поръчка");
            }
            else if (!int.TryParse(orderNumber, out orderNumtoInt))
            {
                MessageBox.Show("Моля въведете числова стойност");
            }
            else if (service.CheckIfOrderExists(orderNumtoInt))
            {
                MessageBox.Show("Поръчка с такъв номер не съществува");
            }
            else
            {
                numberOrder = textBox5.Text;

                this.Hide();
                var currentOrder = new currentOrder();
                currentOrder.Show();
            }

        }
    }
}
