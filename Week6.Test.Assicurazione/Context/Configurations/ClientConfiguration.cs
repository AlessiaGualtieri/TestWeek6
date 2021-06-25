using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Test.Assicurazione.Models;

namespace Week6.Test.Assicurazione.Context.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.CF);
            builder.Property(c => c.CF).IsFixedLength()
                .HasMaxLength(16).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(20)
                .IsRequired();
            builder.Property(c => c.Surname).HasMaxLength(20)
                .IsRequired();
            builder.Property(c => c.Address).HasMaxLength(50)
                .IsRequired();

            //Loading data
            builder.HasData
                (
                new Client
                {
                    CF = "DFNBLL67D56P874P",
                    Name = "Dafne",
                    Surname = "Bella",
                    Address = "via Bernabei, 50"
                }
                );
        }
    }
}
