using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Common.Models;

namespace Common
{
    public interface IRepository<T>
        where T : BaseModel, new()
    {
        void DeleteAll();
        void Delete(T item);
        void Add(T item);
        void Update(T item);
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);
        ObservableCollection<T> GetObservableCollection();
        void LoadAll();
        void Save();
        void Dispose();
    }
}
