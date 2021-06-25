using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Test.Assicurazione
{
    public class Helper
    {
        public static void ShowRecords<T>(ICollection<T> collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }
    }
}
