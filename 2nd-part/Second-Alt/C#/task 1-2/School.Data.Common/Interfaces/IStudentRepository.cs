using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using School.Data.Entity.Models;

namespace School.Data.Interfaces
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        IEnumerable<Student> GetListIncludeTeacher(Expression<Func<Student, bool>> predicate);
        IEnumerable<Student> GetAllIncludeTeacher();
    }
}
