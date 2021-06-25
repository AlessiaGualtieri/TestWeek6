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
    public class TheftPolicyConfiguration : IEntityTypeConfiguration<TheftPolicy>
    {
        public void Configure(EntityTypeBuilder<TheftPolicy> builder)
        {
            builder.Property(tp => tp.PercentageCovered).IsRequired();

            //Loading data
            builder.HasData
                (
                new TheftPolicy
                {
                    DateDrafting = new DateTime(2019, 10, 07),
                    InsuredAmount = 15000,
                    MonthlyRate = 145.87f,
                    Number = 2,
                    PercentageCovered = 15
                }
                );
        }
    }
}
