using System;
using System.Collections.Generic;
using School.Data.Entity.Models;

namespace School.Data.Interfaces
{
    public interface IEntitiesContext : IDisposable
    {
        IList<Student> Students { get; }

        IList<Teacher> Teachers { get; }

        void SaveChanges();
    }
}
