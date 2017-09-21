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

    }
}
