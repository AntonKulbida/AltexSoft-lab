using System;

namespace School.Data.Interfaces
{
    public interface IRepository<T, TKey> : IQueryRepository<T>, IDisposable
        where T : IEntity<TKey>
        where TKey : struct
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
