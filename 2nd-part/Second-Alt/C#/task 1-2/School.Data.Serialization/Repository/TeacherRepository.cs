using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using School.Data.Entity.Models;
using School.Data.Interfaces;
using School.Data.Serialization.Repository.BaseRepositories;

namespace School.Data.Serialization.Repository
{
    internal sealed class TeacherRepository : PersonRepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(Lazy<IEntitiesContext> context)
            : base(context)
        { }

        protected override IList<Teacher> List
        {
            get { return Context.Teachers; }
        }

        public IEnumerable<Teacher> GetListIncludeStudents(Expression<Func<Teacher, bool>> predicate)
        {
            return GetList(predicate);
        }

        public IEnumerable<Teacher> GetAllIncludeStudents()
        {
            return GetAll();
        }
    }
}
