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
    public partial class currentOrder : Form
    {
        private OrderService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';";

      //  string queryString;
        public currentOrder()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
            ShowCurrentOrder();
        }


        private void button1_Click(object sender, EventArgs e)
        {
          //  string pesho = service.orderquery;

            //string dsadas = allOrders.numberOrder;

        }

        private void btn_Main_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }



        private void ShowCurrentOrder()
        {
            string orderNumber = allOrders.numberOrder;

            string orderQuery = service.GetCurrentOrderQuery(orderNumber);

            connection = new MySqlConnection(MyConnectionString);
            List<string> listWitWorkers = new List<string>();

            connection.Open();
            using (connection)
            {
                MySqlCommand command1 = new MySqlCommand(orderQuery, connection);
                MySqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {

                    textBox1.Text = reader["model_name"].ToString();
                    textBox2.Text = reader["client_name"].ToString();
                    textBox3.Text = reader["city"].ToString();
                    textBox4.Text = reader["school"].ToString();
                    textBox5.Text = reader["phone"].ToString();
                    textBox6.Text = reader["test_date"].ToString();
                    textBox7.Text = reader["weding_date"].ToString();
                    textBox8.Text = reader["chest_lap"].ToString();
                    textBox9.Text = reader["podgradna_lap"].ToString();
                    textBox10.Text = reader["waist_measurement"].ToString();

                }

            }


        }
    }
}
