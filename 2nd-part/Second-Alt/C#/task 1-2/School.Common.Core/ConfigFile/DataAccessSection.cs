using System.Configuration;
using School.Common.Core.Enums;
using School.Common.Serialization.Enums;

namespace School.Common.Core.ConfigFile
{
    public class DataAccessSection : ConfigurationSection
    {
        [ConfigurationProperty("storageType", IsRequired = true)]
        public StorageType StorageType
        {
            get { return (StorageType) this["storageType"]; }
            set { this["storageType"] = value; }
        }

        [ConfigurationProperty("serialization")]
        public SerializationElement Serialization
        {
            get { return (SerializationElement)this["serialization"]; }
            set { this["serialization"] = value; }
        }

        [ConfigurationProperty("database")]
        public DatabaseElement Database
        {
            get { return (DatabaseElement)this["database"]; }
            set { this["database"] = value; }
        }

        [ConfigurationProperty("xmlns", IsRequired = false)]
        public string Xmlns
        {
            get
            {
                return this["xmlns"] != null ? this["xmlns"].ToString() : string.Empty;
            }
        }  
    }

    public class SerializationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", DefaultValue = SerializerType.Xml, IsRequired = true)]
        public SerializerType Type
        {
            get { return (SerializerType) this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("filePath", IsRequired = true)]
        public string FilePath
        {
            get { return (string)this["filePath"]; }
            set { this["filePath"] = value; }
        }
    }

    public class DatabaseElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionString", IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }
        [ConfigurationProperty("timeout")]
        public ushort TimeOut
        {
            get { return this["timeout"] is ushort ? (ushort)this["timeout"] : (ushort)0; }
            set { this["ushort"] = value; }
        }
    }
}
