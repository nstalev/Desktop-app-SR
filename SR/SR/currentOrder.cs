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
        List<Worker> workersList3 = new List<Worker>();
        List<Worker> workersList4 = new List<Worker>();


        public currentOrder()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
            workersList1 = GetAllWorkersForCombo();
            workersList2 = GetAllWorkersForCombo();
            workersList3 = GetAllWorkersForCombo();
            workersList4 = GetAllWorkersForCombo();
            ShowCurrentOrder(orderNumber);
            remobeEmptyWorker();
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

                                                   //TODO 
                                                   // update date
                                                   textBox8.Text,
                                                   textBox9.Text,
                                                   textBox10.Text,
                                                   textBox11.Text,
                                                   textBox12.Text,
                                                   textBox13.Text,
                                                   textBox14.Text,
                                                   textBox15.Text,
                                                   textBox16.Text,
                                                   textBox17.Text,
                                                   textBox18.Text,
                                                   textBox19.Text,
                                                   textBox20.Text,
                                                   textBox21.Text,
                                                   textBox22.Text,
                                                   textBox23.Text,
                                                   textBox24.Text,

                                                   textBox27.Text,


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


        //SHOW CURRENT ORDER
        private void ShowCurrentOrder(string orderNumber)
        {
           


            string orderQuery = service.GetCurrentOrderQuery(orderNumber);

            connection = new MySqlConnection(MyConnectionString);

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
                    textBox27.Text = reader["technical_description"].ToString();


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
            ShowCurrentManipulations(orderNumber);
           
        }

        //remove the empty worker
        public void remobeEmptyWorker()
        {
            workersList3.Remove(workersList3[0]);
        }



        // CREATE NEW MANIPULATION
        private void CreateNewManipulation(string orderNumber)
        {

            string manipDescription = textBox71.Text;

            int amount = 0;
            if (!String.IsNullOrEmpty(textBox66.Text))
            {
                    amount = int.Parse(textBox66.Text);
            }

            int timeNeeded = 0;
            if (!String.IsNullOrEmpty(textBox59.Text))
            {
                    timeNeeded = int.Parse(textBox59.Text);
            }

            string worker_id = comboBox10.SelectedValue.ToString();


            string manipulation_date = "";
            if (String.IsNullOrEmpty(textBox52.Text))
            {
                manipulation_date = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                manipulation_date = service.ConverteToDate(textBox52.Text);
            }


            service.createNewManipulation(orderNumber, worker_id, manipDescription, manipulation_date, timeNeeded, amount);


            comboBox10.ResetText();
            textBox71.ResetText();
            textBox66.ResetText();
            textBox59.ResetText();
            textBox52.ResetText();

            ShowCurrentOrder(orderNumber);

            }


        //GET ALL WORKERS FOR COMBOBOX
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


        //FOR MANIPULATIONS
       
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBox10.DataSource = workersList3;
            comboBox10.DisplayMember = "name";
            comboBox10.ValueMember = "id";
        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox22.DataSource = workersList4;
            comboBox22.DisplayMember = "name";
            comboBox22.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string num = orderNumber;

            //validations
            if (comboBox10.SelectedValue == null)
            {
                MessageBox.Show("Моля изберете работник");
            }
            else if(!service.CheckIfIsInteger(textBox66.Text))
            {
                MessageBox.Show("Брой трябва да е число");
            }
            else if (string.IsNullOrEmpty(textBox59.Text) || !service.CheckIfIsInteger(textBox59.Text))
            {
                 MessageBox.Show("Полето Време трябва да бъде попълнено с числова стойност");
            }
           
            else if (!string.IsNullOrEmpty(textBox52.Text) && service.CheckIfDateIsValid(textBox52.Text))
            {
                    MessageBox.Show("Невалидна дата за проба");
                
            }
            else
            {
                CreateNewManipulation(num);
            }


        }

        //SHOW ALL MANIPULATIONS
        public void ShowCurrentManipulations(string orderNumber)
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();

            string selectWorker = service.GetCurrentManipulations(orderNumber);

            MySqlCommand command = new MySqlCommand(selectWorker, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            connection.Close();
        }

        public Padding Padding { get; set; }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.DefaultCellStyle.Font = new Font ("Verdana", 10, FontStyle.Bold);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;



        }
    }
}
