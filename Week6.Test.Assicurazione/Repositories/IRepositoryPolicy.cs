using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Test.Assicurazione.Models;

namespace Week6.Test.Assicurazione.Repositories
{
    public interface IRepositoryPolicy : IRepository<Policy>
    {
        public void ShowPoliciesWithClients();

    }
}
