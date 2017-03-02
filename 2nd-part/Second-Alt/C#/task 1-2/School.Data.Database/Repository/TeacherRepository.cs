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
    internal sealed class TeacherRepository : RepositoryBase<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(Lazy<IEntitiesContext> context)
            : base(context)
        { }

        protected override IDbSet<Teacher> List
        {
            get { return Context.Teachers; }
        }

        public IEnumerable<Teacher> GetListIncludeStudents(Expression<Func<Teacher, bool>> predicate)
        {
            return Collection.Where(predicate).Include(t => t.Students).ToArray();
        }

        public IEnumerable<Teacher> GetAllIncludeStudents()
        {
            return Collection.Include(t => t.Students).ToArray();
        }
    }
}
