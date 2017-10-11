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
    public partial class calcHours : Form
    {
        List<Worker> workersList = new List<Worker>();
        MySqlConnection connection;
        private CalcHoursService service;

        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";
        public calcHours()
        {
            InitializeComponent();
            service = new CalcHoursService();
            workersList = GetAllWorkersForCombo();
            remobeEmptyWorker();
        }

        private void btn_Main6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = workersList;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";
        }

        

        //GET MANIPULATIONS
        private void GetManipulationsAndHours()
        {
            if (comboBox3.SelectedValue != null && string.IsNullOrEmpty(textBox10.Text))
            {
                string worker_id = comboBox3.SelectedValue.ToString();

                string selectQueryByWorker = service.GetSelectQueryByWorker(worker_id);
                ShowCurrentManipulations(selectQueryByWorker);
            }
            else if (comboBox3.SelectedValue == null && !string.IsNullOrEmpty(textBox10.Text))
            {
                string selectQueryByOrderId = service.GetSelectQueryByOrderId(textBox10.Text);
                ShowCurrentManipulations(selectQueryByOrderId);
            }
            else if (comboBox3.SelectedValue != null && !string.IsNullOrEmpty(textBox10.Text))
            {
                string worker_id = comboBox3.SelectedValue.ToString();

                string selectQueryByOrderId = service.GetSelectQueryByWorkerAndOrderId(textBox10.Text, worker_id);
                ShowCurrentManipulations(selectQueryByOrderId);
            }


        }



        //SHOW ALL MANIPULATIONS
        public void ShowCurrentManipulations(string queryString)
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();

            string selectWorker = queryString;

            MySqlCommand command = new MySqlCommand(selectWorker, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            List<int> allHours = new List<int>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                allHours.Add(int.Parse(reader[6].ToString()));
            }

            int sumallHours = allHours.Sum();
            ShowTheTime(sumallHours);
            connection.Close();
        }


        private void ShowTheTime(int sum)
        {
            int hours = sum / 60;
            int minutes = sum % 60;

            textBox1.Text = hours.ToString();
            textBox2.Text = minutes.ToString();

        }



        //remove the empty worker
        public void remobeEmptyWorker()
        {
            workersList.Remove(workersList[0]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox10.Text) && comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Моля изберете някое от полетата");
            }
            else if (!string.IsNullOrEmpty(textBox10.Text) && !service.CheckIfIsInteger(textBox10.Text))
            {
                MessageBox.Show("Полето с номер на поръчка трябва да бъде числова стойност");
            }
            else if (!string.IsNullOrEmpty(textBox10.Text) &&
                service.CheckIfIsInteger(textBox10.Text) &&
                service.CheckIfOrderExists(int.Parse(textBox10.Text)))
            {
                MessageBox.Show("Поръчка с такъв номер не съществува");
            }
            else
            {
                GetManipulationsAndHours();
            }
        }

        private void calcHours_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите програмата ?", "Затваряне на програмата.", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
