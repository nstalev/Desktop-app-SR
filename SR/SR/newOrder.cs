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


            string test_date = DateTime.Now.ToString("yyyyMMdd");
            string weding_date = DateTime.Now.ToString("yyyyMMdd");


            //SELECT  Cut Out Dress Worker
            string cutoutdress_worker;
            int cutoutdress_worker_id = 0;
            if (comboBox3.SelectedItem != null)
            {
                cutoutdress_worker = comboBox3.SelectedItem.ToString();
                cutoutdress_worker_id = service.GetWorkerId(cutoutdress_worker);
            }


            //SELECT  Cut Out Dress Worker
            string made_by_worker;
            int made_by_worker_id = 0;
            if (comboBox4.SelectedItem != null)
            {
                made_by_worker = comboBox4.SelectedItem.ToString();
                made_by_worker_id = service.GetWorkerId(made_by_worker);
            }



            service.CreateNewOrder(textBox1.Text,
                                                   textBox2.Text,
                                                   textBox3.Text,
                                                   textBox4.Text,
                                                   textBox5.Text,
                                                   test_date,
                                                   weding_date,

                                                   cutoutdress_worker_id,
                                                   made_by_worker_id
              );


         



            this.Hide();
            var allOrders = new allOrders();
            allOrders.Show();


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
            comboBox2.Items.Add("Да");
            comboBox2.Items.Add("Не");
        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox22.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox5.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox6.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox7.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox8.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox9.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
        }
    }
}
