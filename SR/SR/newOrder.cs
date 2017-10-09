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
           //Разпъва формата.
           // FormBorderStyle = FormBorderStyle.Sizable;
           // WindowState = FormWindowState.Maximized;
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
           // workersList1 = GetAllWorkersForCombo();
           // workersList2 = GetAllWorkersForCombo(); 
           // workersList3 = GetAllWorkersForCombo();
           // workersList4 = GetAllWorkersForCombo();
           // workersList5 = GetAllWorkersForCombo();
           // workersList6 = GetAllWorkersForCombo();
           // workersList7 = GetAllWorkersForCombo();
           // workersList8 = GetAllWorkersForCombo();
        }

        private void newOrder_Load(object sender, EventArgs e)
        {
           this.TopMost = true;
           this.FormBorderStyle = FormBorderStyle.None;
           this.WindowState = FormWindowState.Maximized;
           
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


            //VALIDATIONS
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Моля въведете име на клиента");
            }
            else if(String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Моля въведете град");
            }
            else if (String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Моля въведете телефон на клиента");
            }
            else if (!String.IsNullOrEmpty(textBox6.Text) && service.CheckIfDateIsValid(textBox6.Text))
            {
                MessageBox.Show("Невалидна дата за проба");
            }
            else if (!String.IsNullOrEmpty(textBox7.Text) && service.CheckIfDateIsValid(textBox7.Text))
            {
                MessageBox.Show("Невалидна дата на сватба");

            }
            else
            {
                CreateOrder();
            }

             

        }

        private void CreateOrder()
        {
            //TEST_DATE
            string test_date = "";
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                test_date = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                test_date = service.ConverteToDate(textBox6.Text);
            }

            //weding_date
            string weding_date = "";
            if (String.IsNullOrEmpty(textBox7.Text))
            {
                weding_date = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                weding_date = service.ConverteToDate(textBox7.Text);
            }

            //SELECT  Cut Out Dress Worker
            string cutoutdress_worker_id = "1";
         //  if (comboBox3.SelectedValue != null)
         //  {
         //      cutoutdress_worker_id = comboBox3.SelectedValue.ToString();
         //  }


            //SELECT  Cut Out Dress Worker
           string made_by_worker_id = "1";
          // if (comboBox4.SelectedValue != null)
          // {
          //     made_by_worker_id = comboBox4.SelectedValue.ToString();
          // }


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
                                    textBox27.Text,

                                    cutoutdress_worker_id,
                                    made_by_worker_id
                                 );

            this.Hide();
            var allOrders = new allOrders();
            allOrders.Show();
        }

     //   private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
     //   {
     //       comboBox3.DataSource = workersList1;
     //       comboBox3.DisplayMember = "name";
     //       comboBox3.ValueMember = "id";
     //   }


            //GET ALL WORKERS
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox7.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox6.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }
    }
}
