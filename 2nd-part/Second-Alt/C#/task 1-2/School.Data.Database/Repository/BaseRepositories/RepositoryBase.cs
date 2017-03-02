using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using School.Common.Core;
using School.Data.Database.Interfaces;
using School.Data.Interfaces;
using School.Data.Repository;

namespace School.Data.Database.Repository.BaseRepositories
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

        protected abstract IDbSet<T> List { get; }

        protected override IQueryable<T> Collection
        {
            get { return List; }
        }

        public virtual void Add(T entity)
        {
            List.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            List.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            List.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void SaveChanges()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    Context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single();
                    var databaseEntry = entry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        throw new InvalidOperationException(Strings.UnableSaveChanges);
                    }

                    entry.OriginalValues.SetValues(databaseEntry);
                }
            } while (saveFailed);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
