using System;
using School.Common.Serialization.Enums;
using School.Common.Serialization.Interfaces;
using School.Common.Serialization.Wrappers;

namespace School.Common.Serialization
{
    public sealed class Serializer<T> : ISerializer<T>
    {
        private readonly ISerializer<T> _serializingStrategy;

        public Serializer(SerializerType type, string path)
        {
            switch (type)
            {
                case SerializerType.Xml:
                    _serializingStrategy = new MyXmlSerializer<T>(path);
                    break;
                case SerializerType.Binary:
                    _serializingStrategy = new MyBinSerializer<T>(path);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public void Serialize(T o)
        {
            _serializingStrategy.Serialize(o);
        }

        public T Deserialize()
        {
            return _serializingStrategy.Deserialize();
        }

        public void Dispose()
        {
            _serializingStrategy.Dispose();
        }
    }
}
