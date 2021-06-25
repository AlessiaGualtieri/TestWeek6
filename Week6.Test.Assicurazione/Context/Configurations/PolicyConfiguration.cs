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
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policy").HasKey(p => p.Number);
            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.DateDrafting).HasColumnType("datetime2")
                .IsRequired();
            builder.Property(p => p.InsuredAmount).IsRequired();
            builder.Property(p => p.MonthlyRate).IsRequired();

            builder.HasDiscriminator<string>("Policy type")
                .HasValue<LifePolicy>("Life policy")
                .HasValue<TheftPolicy>("Threft policy")
                .HasValue<CarInsurance>("Car insurance");

        }
    }
}
