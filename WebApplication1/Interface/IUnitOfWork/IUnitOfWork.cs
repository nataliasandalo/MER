using Api.Servico.Interface.IRepository;

namespace Api.Servico.Interface.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();
    }
}
