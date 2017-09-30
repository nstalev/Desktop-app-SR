using MySql.Data.MySqlClient;
using SR.Models;
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
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";
        string orderNumber = allOrders.numberOrder;
        //  string queryString;

        List<Worker> workersList1 = new List<Worker>();
        List<Worker> workersList2 = new List<Worker>();


        public currentOrder()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
            workersList1 = GetAllWorkersForCombo();
            workersList2 = GetAllWorkersForCombo();
            ShowCurrentOrder(orderNumber);
            
        }



        //UPDATE CURRENT ORDER
        private void button1_Click(object sender, EventArgs e)
        {

            string cutoutdress_worker_id = comboBox3.ValueMember;
            if (comboBox3.SelectedValue != null)
            {
                cutoutdress_worker_id = comboBox3.SelectedValue.ToString();
            }

            string made_by_worker_id = comboBox4.ValueMember;
            if (comboBox4.SelectedValue != null)
            {
                made_by_worker_id = comboBox4.SelectedValue.ToString();
            }

            service.UpdateCurrentOrder(orderNumber,
                                                   textBox1.Text,
                                                   textBox2.Text,
                                                   textBox3.Text,
                                                   textBox4.Text,
                                                   textBox5.Text,

                                                   cutoutdress_worker_id,
                                                   made_by_worker_id
                                                   );



            this.Hide();
            var allOrders = new allOrders();
            allOrders.Show();
        }

        private void btn_Main_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }



        private void ShowCurrentOrder(string orderNumber)
        {
            

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
                    textBox11.Text = reader["low_waist"].ToString();
                    textBox12.Text = reader["lap_hips"].ToString();
                    textBox13.Text = reader["skirt_lenght_front"].ToString();
                    textBox14.Text = reader["skirt_lenght_back"].ToString();
                    textBox15.Text = reader["sleeve_length"].ToString();
                    textBox16.Text = reader["tour_biceps"].ToString();
                    textBox17.Text = reader["length_from_shoulder_to_tq"].ToString();
                    textBox18.Text = reader["length_from_7shp_to_waist"].ToString();
                    textBox19.Text = reader["length_from_7shp_to_floor"].ToString();
                    textBox20.Text = reader["line_of_skirt_attachment"].ToString();
                    textBox21.Text = reader["place_of_skirt_attachment"].ToString();
                    textBox22.Text = reader["princess_number_of_skirts"].ToString();
                    textBox23.Text = reader["italian_tulle"].ToString();
                    textBox24.Text = reader["crystal_tulle"].ToString();
                    textBox25.Text = reader["price"].ToString();
                    textBox26.Text = reader["deposit"].ToString();


                    int cutoutdress_worker_id = int.Parse(reader["cutoutdress_worker_id"].ToString());
                    Worker cutoutdress_worker = workersList1.First(w => w.Id == cutoutdress_worker_id) ;
                    string cutoutdress_worker_name = cutoutdress_worker.Name;
                    comboBox3.Text = cutoutdress_worker_name;
                    comboBox3.ValueMember = cutoutdress_worker_id.ToString();

                    int made_by_worker_id = int.Parse(reader["made_by_worker_id"].ToString());
                    Worker made_by_worker = workersList1.First(w => w.Id == made_by_worker_id);
                    string made_by_worker_name = made_by_worker.Name;
                    comboBox4.Text = made_by_worker_name;
                    comboBox4.ValueMember = made_by_worker_id.ToString();

                }
            }

        }


        public List<Worker> GetAllWorkersForCombo()
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();

            List<Worker> listWitWorkers = new List<Worker>();

            using (connection)
            {
                MySqlCommand command1 = new MySqlCommand(service.GetAllWorkers(), connection);
                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {

                    listWitWorkers.Add(new Worker() { Id = int.Parse(reader[0].ToString()), Name = reader[1].ToString() });
                }

            }

            return listWitWorkers;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = workersList1;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.DataSource = workersList2;
            comboBox4.DisplayMember = "name";
            comboBox4.ValueMember = "id";
        }
    }
}
