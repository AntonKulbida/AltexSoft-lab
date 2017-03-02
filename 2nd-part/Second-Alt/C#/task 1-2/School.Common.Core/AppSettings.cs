using School.Common.Core.Enums;
using School.Common.Serialization.Enums;

namespace School.Common.Core
{
    public static class AppSettings
    {
        public static volatile SerializerType SerializationType;

        public static volatile string FilePath;

        public static volatile StorageType StorageType;

        public static volatile string ConnectionString;

        public static volatile ushort TimeOut;
    }
}
