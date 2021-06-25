using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Test.Assicurazione.Models
{
    abstract public class Policy
    {
        public int Number { get; set; }
        public DateTime DateDrafting { get; set; }
        public float InsuredAmount { get; set; }
        public float MonthlyRate { get; set; }

        public String ClientCF { get; set; }
        public Client Client { get; set; }

        public override string ToString()
        {
            return $"Number: {Number} - Date Draftinf: {DateDrafting} -" +
                $" Insured amount: {InsuredAmount} - Monthly rate: {MonthlyRate}\n";
        }
    }
}
