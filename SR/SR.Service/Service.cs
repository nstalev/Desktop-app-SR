using SR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new SRContext();
        }
        protected SRContext Context { get; }

    }
}
