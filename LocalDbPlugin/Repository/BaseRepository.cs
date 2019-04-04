using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Common;
using Common.Models;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T>, IDisposable
        where T : BaseModel, new()
    {
        private readonly LocalDbContext _dbContext;
        private bool _disposed;

        public BaseRepository(LocalDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new Exception("Data context can not be null!");
            }

            _dbContext = dbContext;
        }

        public void DeleteAll()
        {
            _dbContext.Set<T>().RemoveRange(GetAll());
        }

        public void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Single(item => item.Id == id);
        }

        public ObservableCollection<T> GetObservableCollection()
        {
            return _dbContext.Set<T>().Local;
        }

        public void LoadAll()
        {
            _dbContext.Set<T>().Load();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
