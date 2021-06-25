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
    class RepositoryClient : IRepositoryClient
    {
        public bool AddPolicy(string clientCF, int policyNr)
        {
            bool success = false;

            using(var ctx = new InsuranceContext())
            {
                try
                {
                    Client client = ctx.Clients.Include(c => c.Policies)
                    .FirstOrDefault(c => c.CF == clientCF);
                    Policy policy = ctx.Policies.Find(policyNr);
                    client.Policies.Add(policy);
                    policy.Client = client;
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

        public bool Create(Client item)
        {
            bool success = false;
            if (item == null)
                return success;
            using (var ctx = new InsuranceContext())
            {
                try
                {
                    ctx.Clients.Add(item);
                    ctx.SaveChanges();

                    success = true;
                }catch(SqlException e)
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

        public ICollection<Client> GetAll()
        {
            ICollection<Client> clients;
            using (var ctx = new InsuranceContext())
            {
                clients = ctx.Clients.ToList();
            }
            return clients;
        }
    }
}
