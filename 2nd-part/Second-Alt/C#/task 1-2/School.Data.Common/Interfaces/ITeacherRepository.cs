using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using School.Data.Entity.Models;

namespace School.Data.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher, int>
    {
        IEnumerable<Teacher> GetListIncludeStudents(Expression<Func<Teacher, bool>> predicate);
        IEnumerable<Teacher> GetAllIncludeStudents();
    }
}
