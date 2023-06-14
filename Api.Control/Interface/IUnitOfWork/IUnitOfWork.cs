using Api.Control.Interface.IRepository;

namespace Api.Control.Interface.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();
    }
}
