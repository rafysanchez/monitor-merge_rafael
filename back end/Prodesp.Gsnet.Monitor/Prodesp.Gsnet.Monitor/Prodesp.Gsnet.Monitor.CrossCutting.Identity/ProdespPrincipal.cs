using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.Identity
{
    public class ProdespPrincipal : IProdespPrincipal
    {
        public IIdentity Identity { get; private set; }
        public ProdespPrincipal(IIdentity identity)
        {
            this.Identity = identity;
        }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
