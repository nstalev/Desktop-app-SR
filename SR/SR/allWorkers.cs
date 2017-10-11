using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data.Common;
using SR.Service;
using SR.Models;

namespace SR
{
    public partial class allWorkers : Form
    {
        private WorkerService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";
        List<Worker> workersList1 = new List<Worker>();


        public allWorkers()
        {
            InitializeComponent();

            connection = new MySqlConnection(MyConnectionString);
            service = new WorkerService();
            workersList1 = GetAllWorkersForCombo();
            ShowAllWorkers();
        }

        private void btn_Main6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void btn_createWorker_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Моля напишете име");
            }
            else
            {
                CreateNewWorker();
            }


        }


        private void CreateNewWorker()
        {
            MySqlCommand cmd;
            connection.Open();

            cmd = connection.CreateCommand();
            cmd.CommandText = service.CreateWorker(textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вие създадохте нов работник с име: " + textBox1.Text);

            textBox1.ResetText();
            ShowAllWorkers();

            connection.Close();
            workersList1 = GetAllWorkersForCombo();
        }

        private void allWorkers_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          
            
        }

        private void btn_deleteWorker_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Моля изберете работник");
            }
            else if (comboBox1.SelectedValue != null)
            {
                DeleteWorker(comboBox1.SelectedValue.ToString());
            }

           
        }



        //DELETE Worker
        private void DeleteWorker(string worker_id)
        {
            MySqlCommand cmd;
            connection.Open();


            cmd = connection.CreateCommand();
            cmd.CommandText = service.DeleteWorker(worker_id);
            cmd.ExecuteNonQuery();
             MessageBox.Show("Вие изтрихте работник с ID: " + worker_id);

            connection.Close();

            comboBox1.ResetText();
            comboBox1.DataSource = null;
            ShowAllWorkers();
            workersList1 = GetAllWorkersForCombo();

        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = workersList1;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        public void ShowAllWorkers()
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();

            string selectWorker = service.GetAllWorkers();

            MySqlCommand command = new MySqlCommand(selectWorker, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            connection.Close();
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
    }
}
