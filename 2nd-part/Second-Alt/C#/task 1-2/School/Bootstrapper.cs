using System.Configuration;
using Autofac;
using School.Common.Core;
using School.Common.Core.ConfigFile;
using School.Data;
using School.Interfaces;
using School.Operations;

namespace School
{
    internal static class Bootstrapper
    {
        public static IContainer Container { get; private set; }

        public static void Initialize()
        {
            InitializeAppSettings();

            InitializeIocContainer();
        }

        private static void InitializeIocContainer()
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            RegisterModules(builder);

            Container = builder.Build();
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<Terminal>().As<ITerminal>();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<OperationsModule>();
        }

        private static void InitializeAppSettings()
        {
            var dataAccessConfig = (DataAccessSection)ConfigurationManager.GetSection("dataAccess");

            AppSettings.SerializationType = dataAccessConfig.Serialization.Type;
            AppSettings.FilePath = dataAccessConfig.Serialization.FilePath;
            AppSettings.StorageType = dataAccessConfig.StorageType;
            AppSettings.ConnectionString = dataAccessConfig.Database.ConnectionString;
            AppSettings.TimeOut = dataAccessConfig.Database.TimeOut;
        }
    }
}
