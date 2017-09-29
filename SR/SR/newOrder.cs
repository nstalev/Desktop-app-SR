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
    public partial class newOrder : Form
    {

        private OrderService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";
        List<Worker> workersList1 = new List<Worker>();
        List<Worker> workersList2 = new List<Worker>();
        List<Worker> workersList3 = new List<Worker>();
        List<Worker> workersList4 = new List<Worker>();
        List<Worker> workersList5 = new List<Worker>();
        List<Worker> workersList6 = new List<Worker>();
        List<Worker> workersList7 = new List<Worker>();
        List<Worker> workersList8 = new List<Worker>();
        public newOrder()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
            workersList1 = GetAllWorkersForCombo();
            workersList2 = GetAllWorkersForCombo(); 
            workersList3 = GetAllWorkersForCombo();
            workersList4 = GetAllWorkersForCombo();
            workersList5 = GetAllWorkersForCombo();
            workersList6 = GetAllWorkersForCombo();
            workersList7 = GetAllWorkersForCombo();
            workersList8 = GetAllWorkersForCombo();
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

            bool validator = true;


            //TEST_DATE
            string test_date = "";
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                test_date = DateTime.Now.ToString("yyyyMMdd");
                validator = true;
            }
            else if (service.CheckIfDateIsValid(textBox6.Text))
            {
                MessageBox.Show("Невалидна дата за проба");
                validator = false;
            }
            else
            {
                test_date = service.ConverteToDate(textBox6.Text);
                validator = true;
            }

            //weding_date
            string weding_date = "";
            if (String.IsNullOrEmpty(textBox7.Text))
            {
                weding_date = DateTime.Now.ToString("yyyyMMdd");
                validator = true;
            }
            else if (service.CheckIfDateIsValid(textBox7.Text))
            {
                MessageBox.Show("Невалидна дата на сватба");
                validator = false;
            }
            else
            {
                weding_date = service.ConverteToDate(textBox7.Text);
                validator = true;
            }




            //SELECT  Cut Out Dress Worker
            string cutoutdress_worker_id = "1";
            if (comboBox3.SelectedValue != null)
            {
                cutoutdress_worker_id = comboBox3.SelectedValue.ToString();
            }



            //SELECT  Cut Out Dress Worker
            string made_by_worker_id = "1";
            if (comboBox3.SelectedValue != null)
            {
                made_by_worker_id = comboBox4.SelectedValue.ToString();
            }


            if (validator)
            {
                service.CreateNewOrder(textBox1.Text,
                                       textBox2.Text,
                                       textBox3.Text,
                                       textBox4.Text,
                                       textBox5.Text,
                                       test_date,
                                       weding_date,
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
                                       textBox25.Text,
                                       textBox26.Text,

                                       cutoutdress_worker_id,
                                       made_by_worker_id
                                    );

                this.Hide();
                var allOrders = new allOrders();
                allOrders.Show();
            }




            connection.Close();

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
            comboBox22.DataSource = workersList3;
            comboBox22.DisplayMember = "name";
            comboBox22.ValueMember = "id";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.DataSource = workersList4;
            comboBox5.DisplayMember = "name";
            comboBox5.ValueMember = "id";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.DataSource = workersList5;
            comboBox6.DisplayMember = "name";
            comboBox6.ValueMember = "id";
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.DataSource = workersList6;
            comboBox7.DisplayMember = "name";
            comboBox7.ValueMember = "id";
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.DataSource = workersList7;
            comboBox8.DisplayMember = "name";
            comboBox8.ValueMember = "id";
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.DataSource = workersList8;
            comboBox9.DisplayMember = "name";
            comboBox9.ValueMember = "id";
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
    }
}
