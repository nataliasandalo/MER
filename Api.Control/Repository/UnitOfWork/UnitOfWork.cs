using System;
using Api.Control.Interface.IRepository;
using Api.Control.Interface.IUnitOfWork;
using Api.Control.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Control.Repository.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
