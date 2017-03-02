using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using School.Data.Interfaces;

namespace School.Data.Repository
{
    public abstract class QueryRepositoryBase<T> : IQueryRepository<T>
        where T : class
    {
        protected abstract IQueryable<T> Collection { get; }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return Collection.Where(predicate).ToArray();
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.ToArray();
        }
    }
}
