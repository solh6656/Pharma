using Pharma.Domin.Enttes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma.Data.IRepositories
{
    public interface IGenericRepository<T> where T : Auditable
    {
        T Create(T source);
        bool Delete(long id);
        T Update(long id, T source);
        T Get(long id);
        IEnumerable<T> GetAll();
    }
}
