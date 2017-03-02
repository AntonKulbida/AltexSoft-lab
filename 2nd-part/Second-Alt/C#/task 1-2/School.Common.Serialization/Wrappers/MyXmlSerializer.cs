using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace School.Common.Serialization.Wrappers
{
    internal sealed class MyXmlSerializer<T> : SerializerBase<T>
    {
        private readonly XmlSerializer _serializer;

        private readonly Encoding _encoding = Encoding.UTF8;

        public MyXmlSerializer(string path)
            : base(path)
        {
            _serializer = new XmlSerializer(typeof(T));
        }

        protected override void SerializeImpl(object o)
        {
            using (var writer = new StreamWriter(FileStream, _encoding, 1024, true))
            {
                _serializer.Serialize(writer, o);
                writer.Flush();
            }
        }

        protected override object DeserializeImpl()
        {
            using (var reader = new StreamReader(FileStream, _encoding, false, 1024, true))
            {
                return _serializer.Deserialize(reader);
            }
        }
    }
}
