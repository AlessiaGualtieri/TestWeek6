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
    public class LifePolicyConfiguration : IEntityTypeConfiguration<LifePolicy>
    {
        public void Configure(EntityTypeBuilder<LifePolicy> builder)
        {
            builder.Property(l => l.AgeInsured).IsRequired();

            //Loading data
            builder.HasData
                (
                new LifePolicy
                {
                    DateDrafting = new DateTime(2019, 10, 07),
                    InsuredAmount = 15000,
                    MonthlyRate = 145.87f,
                    Number = 3,
                    AgeInsured = 55
                }
                );
        }
    }
}
