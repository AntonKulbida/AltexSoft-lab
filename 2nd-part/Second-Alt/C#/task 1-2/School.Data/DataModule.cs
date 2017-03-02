using System;
using Autofac;
using School.Common.Core;
using School.Common.Core.Enums;
using School.Data.Database;
using School.Data.Serialization;

namespace School.Data
{
    public sealed class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            switch (AppSettings.StorageType)
            {
                case StorageType.Serialization:
                    builder.RegisterModule<SerializationModule>();
                    break;
                case StorageType.Database:
                    builder.RegisterModule<DatabaseModule>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("AppSettings.StorageType", AppSettings.StorageType, null);
            }
        }
    }
}
