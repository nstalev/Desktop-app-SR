using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SR.Service
{
    public class CalcHoursService
    {
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";

        public CalcHoursService()
        {
            connection = new MySqlConnection(MyConnectionString);
        }

        //CHECK IF THE INPUT IS INTEGER
        public bool CheckIfIsInteger(string text)
        {
            string pattern = @"^\d+$";
            Regex regex = new Regex(pattern);

            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            else
            {
                return regex.IsMatch(text);

            }
        }


        //CHECK IF ORDER EXISTS
        public bool CheckIfOrderExists(int orderNum)
        {
            string createQuery = $"SELECT * FROM orders WHERE order_id ='{orderNum}'";
            int result = 0;

            connection.Open();
            using (connection)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                    result = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {

                }
            }

            if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public string GetAllWorkers()
        {
            return "SELECT * FROM workers";
        }



        public string GetSelectQueryByWorker(string worker_id)
        {
            return "SELECT m.order_id AS 'Поръчна номер', w.worker_name AS 'Работник', m.description AS 'Описание', m.manipulation_date AS 'Дата', " +
                "m.amount AS 'Брой', m.time_needed AS 'Време' " +
                 $"FROM manipulations AS m " +
                 "INNER JOIN workers as w " +
                 "ON m.worker_id = w.worker_id " +
                 $"WHERE m.worker_id = '{worker_id}' ";
        }

        public string GetSelectQueryByWorkerAndOrderId(string order_id, string worker_id)
        {
            return "SELECT m.order_id AS 'Поръчна номер', w.worker_name AS 'Работник', m.description AS 'Описание', m.manipulation_date AS 'Дата', " +
              "m.amount AS 'Брой', m.time_needed AS 'Време' " +
               $"FROM manipulations AS m " +
               "INNER JOIN workers as w " +
               "ON m.worker_id = w.worker_id " +
               $"WHERE m.order_id = '{order_id}' " +
                $"AND m.worker_id = '{worker_id}' ";
        }

        public string GetSelectQueryByOrderId(string order_id)
        {
            return "SELECT m.order_id AS 'Поръчна номер', w.worker_name AS 'Работник', m.description AS 'Описание', m.manipulation_date AS 'Дата', " +
                "m.amount AS 'Брой', m.time_needed AS 'Време' " +
                 $"FROM manipulations AS m " +
                 "INNER JOIN workers as w " +
                 "ON m.worker_id = w.worker_id " +
                 $"WHERE m.order_id = '{order_id}' ";
        }
    }
}
