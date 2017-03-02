using System;
using System.IO;
using School.Common.Serialization.Interfaces;

namespace School.Common.Serialization.Wrappers
{
    internal abstract class SerializerBase<T> : ISerializer<T>
    {
        protected readonly FileStream FileStream;

        protected SerializerBase(string path)
        {
            FileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public virtual void Dispose()
        {
            FileStream.Dispose();
        }

        public void Serialize(T o)
        {
            if(FileStream.Length > 0)
                ClearStream();

            SerializeImpl(o);
        }

        public T Deserialize()
        {
            if(FileStream.Position != 0)
                ResetStream();

            var o = DeserializeImpl();

            return (T)o;
        }

        protected abstract void SerializeImpl(object o);

        protected abstract object DeserializeImpl();

        private void ClearStream()
        {
            ValidateStreamSeekable();

            FileStream.Seek(0, SeekOrigin.Begin);
            FileStream.SetLength(0);
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
