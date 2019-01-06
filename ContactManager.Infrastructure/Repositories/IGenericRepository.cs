using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure
{
    public interface IGenericRepository<T>
    {        
        IQueryable<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
