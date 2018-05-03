using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.Identity
{
    public class ProdespIdentity : IProdespIdentity
    {
        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }
        public ProdespIdentity(string name)
        {
            this.Name = name;
        }

    }
}
