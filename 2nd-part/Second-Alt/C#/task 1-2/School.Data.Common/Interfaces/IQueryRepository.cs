using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace School.Data.Interfaces
{
    public interface IQueryRepository<T>
    {
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
