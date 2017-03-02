using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using School.Data.Entity.Models;
using School.Data.Interfaces;
using School.Data.Serialization.Repository.BaseRepositories;

namespace School.Data.Serialization.Repository
{
    internal sealed class StudentRepository : PersonRepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(Lazy<IEntitiesContext> context)
            : base(context)
        { }

        protected override IList<Student> List
        {
            get { return Context.Students; }
        }

        public IEnumerable<Student> GetListIncludeTeacher(Expression<Func<Student, bool>> predicate)
        {
            return GetList(predicate);
        }

        public IEnumerable<Student> GetAllIncludeTeacher()
        {
            return GetAll();
        }
    }
}
