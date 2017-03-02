using Autofac;
using Autofac.Core;
using School.Common.Core;
using School.Common.Serialization;
using School.Common.Serialization.Enums;
using School.Common.Serialization.Interfaces;
using School.Data.Interfaces;
using School.Data.Serialization.Entity;
using School.Data.Serialization.Interfaces;
using School.Data.Serialization.Repository;
using School.Data.Serialization.Services;
using School.Data.Serialization.Services.SerializationServices;

namespace School.Data.Serialization
{
    public sealed class SerializationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(SerializationSaveRestoreService<>))
                .As(typeof(ISaveRestoreService<>));
            builder.RegisterGeneric(typeof(Serializer<>))
                .As(typeof(ISerializer<>))
                .WithParameter(new ResolvedParameter((pi, ctx) => pi.ParameterType == typeof(SerializerType) && pi.Name == "type", (pi, ctx) => AppSettings.SerializationType))
                .WithParameter(new ResolvedParameter((pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "path", (pi, ctx) => AppSettings.FilePath));
            builder.RegisterType<DataContextSaveRestoreService>();
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
