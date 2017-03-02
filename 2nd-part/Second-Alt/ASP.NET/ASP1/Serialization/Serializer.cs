using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace Serialization
{
    public class Serializer<T>
    {
        private readonly FileStream FileStream;
        private readonly XmlSerializer _serializer;
        private readonly Encoding _encoding = Encoding.UTF8;

        
        public Serializer(string path)
        {
            _serializer = new XmlSerializer(typeof (T));
            FileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Serialize(object o)
        {
            if (FileStream.Length > 0)
                ClearStream();

            using (var writer = new StreamWriter(FileStream, _encoding, 1024))
            {
                _serializer.Serialize(writer, o);
                writer.Flush();
            }
        }

        public  T Deserialize()
        {
            if (FileStream.Position != 0)
                ResetStream();
            using (var reader = new StreamReader(FileStream, _encoding, false, 1024, true))
            {
                return (T)_serializer.Deserialize(reader);
            }
        }

        private void ClearStream()
        {
            ValidateStreamSeekable();
            FileStream.Seek(0, SeekOrigin.Begin);
        }

        public void Dispose()
        {
            FileStream.Dispose();
        }

        private void ResetStream()
        {
            ValidateStreamSeekable();

            FileStream.Seek(0, SeekOrigin.Begin);
        }

        private void ValidateStreamSeekable()
        {
            if (!FileStream.CanSeek)
                throw new InvalidOperationException("Stream does not support Seeking");
        }
    }
}
