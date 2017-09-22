using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public class OrderService 
    {

        public string CreateNewOrder(string model_name,
                                     string client_name,
                                     string city,
                                     string school,
                                     string phone,
                                     string test_date,
                                     string weding_date

            )
        {

            return "INSERT INTO orders " +
                        "(" +
                            "model_name, " +
                            "client_name, " +
                            "city, " +
                            "school, " +
                            "phone, " +
                            "test_date, " +
                            "weding_date " +

                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{model_name}', " +
                        $"'{client_name}', " +
                        $"'{city}', " +
                        $"'{school}', " +
                        $"'{phone}', " +
                        $"'{test_date}', " +
                        $"'{weding_date}' " +

                         ")";
        }


        public string selectOnlyWorkerName()
        {
            return "SELECT worker_name FROM workers";
        }


        public string GetAllOrders()
        {
            return "SELECT * FROM orders";
        }




    }
}
