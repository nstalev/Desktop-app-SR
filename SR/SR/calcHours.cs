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



    }
}
