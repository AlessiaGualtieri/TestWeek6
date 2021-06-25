using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Test.Assicurazione.Models
{
    public class CarInsurance : Policy
    {
        public String Plate { get; set; }
        public int Displacement { get; set; }

        public override string ToString()
        {
            return $"Number: {Number} - Date Draftinf: {DateDrafting} -" +
                $" Insured amount: {InsuredAmount} - Monthly rate: {MonthlyRate} -" +
                $" Plate: {Plate} - Displacement: {Displacement}\n";
        }
    }
}
