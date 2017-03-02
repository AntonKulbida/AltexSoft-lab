using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using School.Data.Database.Interfaces;
using School.Data.Database.Repository.BaseRepositories;
using School.Data.Entity.Models;
using School.Data.Interfaces;

namespace School.Data.Database.Repository
{
    internal sealed class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
    {
        public StudentRepository(Lazy<IEntitiesContext> context)
            : base(context)
        { }

        protected override IDbSet<Student> List
        {
            get { return Context.Students; }
        }

        public IEnumerable<Student> GetListIncludeTeacher(Expression<Func<Student, bool>> predicate)
        {
            return Collection.Where(predicate).Include(s => s.Teacher).ToArray();
        }

        public IEnumerable<Student> GetAllIncludeTeacher()
        {
            return Collection.Include(s => s.Teacher).ToArray();
        }
    }
}
