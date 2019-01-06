using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected ContactDbContext DatabaseCotext { get; set; }
        public IQueryable<T> GetAll()
        {
            return DatabaseCotext.Set<T>().AsQueryable();
        }
                
        public int Insert(T entity)
        {
            DatabaseCotext.Set<T>().Add(entity);
            DatabaseCotext.SaveChanges();

            return 0;
        }

        public int Update(T entity)
        {
            DatabaseCotext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            DatabaseCotext.SaveChanges();

            return 0;
        }

        public int Delete(T entity)
        {
            DatabaseCotext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            DatabaseCotext.SaveChanges();

            return 0;
        }
    }
}
