using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Test.Assicurazione.Repositories
{
    public interface IRepository<T>
    {
        public ICollection<T> GetAll();
        public bool Create(T item);
    }
}
