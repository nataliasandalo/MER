namespace Api.Control.Interface.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
