using System.Runtime.Serialization.Formatters.Binary;

namespace School.Common.Serialization.Wrappers
{
    internal sealed class MyBinSerializer<T> : SerializerBase<T>
    {
        private readonly BinaryFormatter _serializer;

        public MyBinSerializer(string path)
            : base(path)
        {
            _serializer = new BinaryFormatter();
        }

        protected override void SerializeImpl(object o)
        {
            _serializer.Serialize(FileStream, o);
        }

        protected override object DeserializeImpl()
        {
            return _serializer.Deserialize(FileStream);
        }
    }
}
