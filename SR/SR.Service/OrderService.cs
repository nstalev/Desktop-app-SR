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
                                     string phone
                                          
            )
        {

            return "INSERT INTO orders " +
                        "(" +
                            "model_name, " +
                            "client_name, " +
                            "city, " +
                            "school, " +
                            "phone " +
                            
                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{model_name}', " +
                        $"'{client_name}', " +
                        $"'{city}', " +
                        $"'{school}', " +
                        $"'{phone}' " +
                         ")";
        }


        public string selectOnlyWorkerName()
        {
            return "SELECT worker_name FROM workers";
        }




    }
}
