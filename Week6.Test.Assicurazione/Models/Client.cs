using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Test.Assicurazione.Models
{
    public class Client
    {
        public String CF { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }

        public ICollection<Policy> Policies { get; set; }

        public override string ToString()
        {
            return $"CF: {CF} - Name: {Name} - Surname: {Surname} - Address: {Address}\n";
        }
    }
}
