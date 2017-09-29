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

namespace SR
{
    public partial class allWorkers : Form
    {
        private WorkerService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";


        public allWorkers()
        {
            InitializeComponent();

            connection = new MySqlConnection(MyConnectionString);
            service = new WorkerService();
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
            MySqlCommand cmd;
            connection.Open();
          
                cmd = connection.CreateCommand();
                cmd.CommandText = service.CreateWorker(textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Вие създадохте нов работник с име: " + textBox1.Text);

            textBox1.ResetText();
            ShowAllWorkers();

            connection.Close();
        }

        private void allWorkers_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          
            
        }

        private void btn_deleteWorker_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            connection.Open();


            string deleteWorker = comboBox1.SelectedItem.ToString();

            cmd = connection.CreateCommand();
            cmd.CommandText = service.DeleteWorker(deleteWorker);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вие изтрихте работник с име: " + deleteWorker);


            MySqlCommand command = new MySqlCommand(service.DeleteWorker(deleteWorker), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            connection.Close();

            comboBox1.Items.Clear();
            comboBox1.ResetText();
            ShowAllWorkers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();

            connection.Open();
            MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["worker_name"]);
                }
            }
            connection.Close();
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
    }
}
