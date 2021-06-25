using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Test.Assicurazione.Context;
using Week6.Test.Assicurazione.Models;

namespace Week6.Test.Assicurazione.Repositories
{
    class RepositoryPolicy : IRepositoryPolicy
    {
        public bool Create(Policy item)
        {
            bool success = false;
            if (item == null)
                return success;
            using (var ctx = new InsuranceContext())
            {
                try
                {
                    ctx.Policies.Add(item);
                    ctx.SaveChanges();

                    success = true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        public ICollection<Policy> GetAll()
        {
            ICollection<Policy> clients;
            using (var ctx = new InsuranceContext())
            {
                clients = ctx.Policies.ToList();
            }
            return clients;
        }

        public void ShowPoliciesWithClients()
        {
            using (var ctx = new InsuranceContext())
            {
                ICollection<Policy> policies = ctx.Policies.Include(p => p.Client).ToList();
                foreach (var item in policies)
                {
                    Console.WriteLine(item);
                    if (item.ClientCF != null)
                        Console.WriteLine("This policy has client:");
                        Console.WriteLine(item.Client);
                }
            }
        }
    }
}
