using System;
using System.Collections.Generic;
using System.Linq;
using School.Data.Interfaces;
using School.Data.Repository;

namespace School.Data.Serialization.Repository.BaseRepositories
{
    internal abstract class RepositoryBase<T, TKey> : QueryRepositoryBase<T>, IRepository<T, TKey>
        where T : class, IEntity<TKey>
        where TKey : struct 
    {
        private readonly Lazy<IEntitiesContext> _context;

        protected IEntitiesContext Context
        {
            get { return _context.Value; }
        }

        protected RepositoryBase(Lazy<IEntitiesContext> context)
        {
            _context = context;
        }

        protected override IQueryable<T> Collection
        {
            get { return List.AsQueryable(); }
        }

        protected abstract IList<T> List { get; }

        public virtual void Add(T entity)
        {
            FillId(entity);
            
            List.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            List.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            var index = List.IndexOf(entity);

            if (index == -1)
                return;

            List[index] = entity;
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        protected abstract void FillId(T entity);
    }
}
