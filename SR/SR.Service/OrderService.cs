using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public class OrderService 
    {
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';";

        public OrderService()
        {
            connection = new MySqlConnection(MyConnectionString);

        }
        public void CreateNewOrder(string model_name,
                                     string client_name,
                                     string city,
                                     string school,
                                     string phone,
                                     string test_date,
                                     string weding_date,

                                     string cutoutdress_worker_id,
                                     string made_by_worker_id
            )
        {

            connection.Open();

            string createQuery ="INSERT INTO orders " +
                        "(" +
                            "model_name, " +
                            "client_name, " +
                            "city, " +
                            "school, " +
                            "phone, " +
                            "test_date, " +
                            "weding_date, " +

                            "cutoutdress_worker_id, " +
                            "made_by_worker_id " +

                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{model_name}', " +
                        $"'{client_name}', " +
                        $"'{city}', " +
                        $"'{school}', " +
                        $"'{phone}', " +
                        $"'{test_date}', " +
                        $"'{weding_date}', " +

                        $"'{cutoutdress_worker_id}', " +
                        $"'{made_by_worker_id}' " +
                         ")";

            

            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                cmd.ExecuteNonQuery();
            }
        }


        public string selectOnlyWorkerName()
        {
            return "SELECT worker_name FROM workers";
        }


        public int GetWorkerId(string worker)
        {
            string createQuery = $"SELECT worker_id FROM workers WHERE worker_name ='{worker}'";
              int result = 0;

            connection.Open();
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                 result = (int)cmd.ExecuteScalar();

            }
            return result;
        }


        public string GetAllOrders()
        {
            return "SELECT o.order_id, o.model_name, o.client_name, o.city, o.phone, " +
                "w.worker_name AS 'Cut out Dress by', wo.worker_name AS 'Dress made by'" +
                "FROM orders AS o " +
                "INNER JOIN workers as w " +
                "ON o.cutoutdress_worker_id = w.worker_id " +
                "INNER JOIN workers as wo " +
                "ON o.made_by_worker_id = wo.worker_id " +
                "ORDER BY o.order_id DESC";
        }




    }
}
