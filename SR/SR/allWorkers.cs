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
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';";

        public allWorkers()
        {
            InitializeComponent();

            connection = new MySqlConnection(MyConnectionString);
            service = new WorkerService();
        }


        private void btn_Main6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void btn_createWorker_Click(object sender, EventArgs e)
        {
            //MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
          
                cmd = connection.CreateCommand();
                cmd.CommandText = service.CreateWorker(textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Вие създадохте нов работник с име: " + textBox1.Text);

            string selectWorker = "SELECT * FROM workers";

            MySqlCommand command = new MySqlCommand(selectWorker, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
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
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        //   MySqlCommand cmd;
        //   string selectQuery = "SELECT * FROM workers";
        //
        //   connection.Open();
        //   MySqlCommand command = new MySqlCommand(selectQuery, connection);
        //   cmd = connection.CreateCommand();
        //   cmd.CommandText = selectQuery;
        //   cmd.ExecuteNonQuery();
        //   MySqlDataAdapter da = new MySqlDataAdapter(command);
        //
        //   DataTable dt = new DataTable();
        //   da.Fill(dt);
        //   foreach (DataRow row in dt.Rows)
        //   {
        //       string rowz = string.Format("{0}", row.ItemArray[0]);
        //       comboBox1.Items.Add(rowz);
        //       comboBox1.AutoCompleteCustomSource.Add(row.ItemArray[0].ToString());
        //   }
        //
        //   connection.Close();
        }
    }
}
