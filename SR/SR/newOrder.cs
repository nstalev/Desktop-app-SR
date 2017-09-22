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
    public partial class newOrder : Form
    {

        private OrderService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';";

        public newOrder()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
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

        //----------CREATE NEW ORDER------------------------
        private void btn_Save_Click(object sender, EventArgs e)
        {
            connection.Open();

            string createQuery = service.CreateNewOrder(textBox1.Text,
                                                   textBox2.Text,
                                                   textBox3.Text,
                                                   textBox4.Text,
                                                   textBox5.Text
              );


            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                cmd.ExecuteNonQuery();
            }

        

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox3.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox4.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Да");
            comboBox1.Items.Add("Не");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Да");
            comboBox1.Items.Add("Не");
        }
    }
}
