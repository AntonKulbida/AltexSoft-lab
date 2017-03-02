using System;
using System.Linq;
using School.Data.Interfaces;

namespace School.Data.Serialization.Repository.BaseRepositories
{
    internal abstract class PersonRepositoryBase<T> : RepositoryBase<T, int> 
        where T : class, IEntity<int>
    {
        protected PersonRepositoryBase(Lazy<IEntitiesContext> context) : base(context)
        { }

        protected override void FillId(T entity)
        {
            if (entity.Id == -1)
            {
                entity.Id = GetId();
                return;
            }

            if (List.Contains(entity))
            {
                throw new InvalidOperationException("Violation of primary key constraint. Cannot insert duplicate key in object 'Teachers'");
            }
        }

        private int GetId()
        {
            return List.Select(i => i.Id).DefaultIfEmpty().Max() + 1;
        }
    }
}
