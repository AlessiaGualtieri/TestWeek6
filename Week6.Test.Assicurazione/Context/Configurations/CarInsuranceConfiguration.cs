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
    public class CarInsuranceConfiguration : IEntityTypeConfiguration<CarInsurance>
    {
        public void Configure(EntityTypeBuilder<CarInsurance> builder)
        {
            builder.Property(ci => ci.Plate).IsFixedLength()
                .HasMaxLength(5).IsRequired();
            builder.Property(ci => ci.Displacement).IsRequired();


            //Loading data
            builder.HasData
                (
                new CarInsurance
                {
                    DateDrafting = new DateTime(2019, 10, 07),
                    InsuredAmount = 15000,
                    MonthlyRate = 145.87f,
                    Number = 1,
                    Plate = "CP026",
                    Displacement = 7 
                }
                );
        }
    }
}
