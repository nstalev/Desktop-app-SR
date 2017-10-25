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
    public partial class allOrders : Form
    {
        private OrderService service;
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";

        public static string numberOrder;
        public allOrders()
        {
            InitializeComponent();
            connection = new MySqlConnection(MyConnectionString);
            service = new OrderService();
            ShowAllOrders(service.GetAllOrders());
           //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
           //dataGridView1.AllowUserToResizeRows = false;

            DataGridViewRow row = this.dataGridView1.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 35;
            //row.MinimumHeight = 20;
        }

        private void btn_Main3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            
            if (dgv.CurrentRow.Selected)
            {
                this.Hide();
                var currentOrder = new currentOrder();
                currentOrder.Show();
            }
        }


        public void ShowAllOrders(string querySelect)
        {
            connection = new MySqlConnection(MyConnectionString);
            connection.Open();

            //string querySelect = service.GetAllOrders();

            MySqlCommand command = new MySqlCommand(querySelect, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            connection.Close();
        }


        //------------VALIDATIONS---------
        private void btn_search_Click(object sender, EventArgs e)
        {
            string orderNumber = textBox5.Text;
            int orderNumtoInt = 0;

            if (String.IsNullOrEmpty(orderNumber))
            {
                MessageBox.Show("Моля изберете номер на поръчка");
            }
            else if (!int.TryParse(orderNumber, out orderNumtoInt))
            {
                MessageBox.Show("Моля въведете числова стойност");
            }
            else if (service.CheckIfOrderExists(orderNumtoInt))
            {
                MessageBox.Show("Поръчка с такъв номер не съществува");
            }
            else
            {
                numberOrder = textBox5.Text;

                this.Hide();
                var currentOrder = new currentOrder();
                currentOrder.Show();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }


       // private void SearchOrder()
       // {
       //     if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
       //     {
       //         MessageBox.Show("Моля попълнете само едно от полетата за търсене");
       //     }
       //
       //
       // }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Моля попълнете само едно от полетата за търсене");
            }
            else if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                string querySelect = service.GetAllOrders();
                ShowAllOrders(querySelect);
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                string querySelect = service.GetOrdersByClientName(textBox1.Text);
                ShowAllOrders(querySelect);
            }
            else if (String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                string querySelect = service.GetOrdersByPhoneNumber(textBox2.Text);
                ShowAllOrders(querySelect);
            }
        }


        //Auto Complete Client Name
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            this.textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (t.Text.Length >= 2)
                {
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(service.GetAllClientNames());

                    this.textBox1.AutoCompleteCustomSource = collection;
                }
            }
        }

        //Auto Complete Client Name
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            this.textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (t.Text.Length >= 2)
                {
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(service.GetAllPhoneNumbers());

                    this.textBox2.AutoCompleteCustomSource = collection;
                }
            }
        }

        private void allOrders_DoubleClick(object sender, EventArgs e)
        {
           this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           this.dataGridView1.MultiSelect = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            e.CellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold);
        }

        private void dataGridView1_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void allOrders_FormClosing(object sender, FormClosingEventArgs e)
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
