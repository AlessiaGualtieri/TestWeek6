﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Test.Assicurazione.Models
{
    public class LifePolicy : Policy
    {
        public int AgeInsured { get; set; }

        public override string ToString()
        {
            return $"Number: {Number} - Date Draftinf: {DateDrafting} -" +
                $" Insured amount: {InsuredAmount} - Monthly rate: {MonthlyRate} -" +
                $" Age insured: {AgeInsured}\n";
        }
    }
}
