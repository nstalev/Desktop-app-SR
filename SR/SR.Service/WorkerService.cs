using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public class WorkerService
    {

        public string CreateWorker (string textBox)
        {
            return "INSERT INTO workers(worker_name) VALUES('" + textBox + "')";
        }


        public string GetAllWorkers()
        {
            return "SELECT * FROM workers";
        }

        public string DeleteWorker(string comboBox)
        {
            return $"DELETE FROM workers WHERE worker_name = '{comboBox}'";
        }

        public string selectOnlyWorkerName()
        {
            return "SELECT worker_name FROM workers";
        }   
    }
}
