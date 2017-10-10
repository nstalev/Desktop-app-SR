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
        }

        private void btn_Main3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Main = new Main();
            Main.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TextBox t = sender as TextBox;
            if (t != null)
            {
                //say you want to do a search when user types 3 or more chars
                if (t.Text.Length >= 1)
                {
                    //SuggestStrings will have the logic to return array of strings either from cache/db
                    string[] arr = SuggestStrings(t.Text);

                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(arr);

                    this.textBox1.AutoCompleteCustomSource = collection;
                }
            }
        }

        private string[] SuggestStrings(object getAllClientNames)
        {
            string[] arrayString = service.GetAllClientNames();

            return arrayString;
        }
    }
}
