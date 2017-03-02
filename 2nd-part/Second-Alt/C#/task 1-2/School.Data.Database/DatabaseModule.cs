using Autofac;
using School.Data.Database.Entity;
using School.Data.Database.Interfaces;
using School.Data.Database.Repository;
using School.Data.Interfaces;

namespace School.Data.Database
{
    public sealed class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Entities>()
                .As<IEntitiesContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TeacherRepository>()
                .As<ITeacherRepository>();
            builder.RegisterType<StudentRepository>()
                .As<IStudentRepository>();
        }
    }
}
