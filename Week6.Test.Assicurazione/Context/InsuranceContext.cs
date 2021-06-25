using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Test.Assicurazione.Context.Configurations;
using Week6.Test.Assicurazione.Models;

namespace Week6.Test.Assicurazione.Context
{
    public class InsuranceContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False;
                Integrated Security = true;
                Initial Catalog = Insurance1;
                Server = .\SQLEXPRESS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Policy>(new PolicyConfiguration());
            modelBuilder.ApplyConfiguration<LifePolicy>(new LifePolicyConfiguration());
            modelBuilder.ApplyConfiguration<TheftPolicy>(new TheftPolicyConfiguration());
            modelBuilder.ApplyConfiguration<CarInsurance>(new CarInsuranceConfiguration());

            //Relation
            modelBuilder.Entity<Policy>().HasOne(p => p.Client)
                .WithMany(c => c.Policies)
                .HasForeignKey(p => p.ClientCF);
        }
    }
}
