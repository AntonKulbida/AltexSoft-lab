using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using School.Data.Entity.Models;

namespace School.Data.Database.Interfaces
{
    public interface IEntitiesContext : IDisposable
    {
        DbSet<Student> Students { get; }

        DbSet<Teacher> Teachers { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
}
