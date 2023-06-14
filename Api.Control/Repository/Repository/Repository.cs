using Api.Control.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Api.Control.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
