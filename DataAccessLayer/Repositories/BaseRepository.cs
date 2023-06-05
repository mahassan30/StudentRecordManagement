using DataAccessLayer.MyModels;
using Interfacces.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T>:  IBaseRepository<T> where T : class
    {
        private readonly StudentRecordContext dbContext;
        private readonly DbSet<T> dbSet;

        public BaseRepository(StudentRecordContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
