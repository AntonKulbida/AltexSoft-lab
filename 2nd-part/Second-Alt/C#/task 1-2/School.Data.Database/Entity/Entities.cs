using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using School.Common.Core;
using School.Data.Database.Interfaces;
using School.Data.Entity.Models;

namespace School.Data.Database.Entity
{
    internal sealed class Entities : DbContext, IEntitiesContext
    {
       	public Entities() : base(AppSettings.ConnectionString)
         {
           if (AppSettings.TimeOut > 0)
           {
             base.Database.CommandTimeout = AppSettings.TimeOut;
            }
         }

    
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Teacher>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Student>()
                .HasOptional<Teacher>(s => s.Teacher)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TeacherId);
        }

        #region IEntitiesContext implementation

        void IEntitiesContext.SaveChanges()
        {
            base.SaveChanges();
        }

        #endregion
    }
}
