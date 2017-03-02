using School.Common.Serialization.Interfaces;
using School.Data.Serialization.Interfaces;

namespace School.Data.Serialization.Services.SerializationServices
{
    internal sealed class SerializationSaveRestoreService<T> : SerializationServiceBase<T>, ISaveRestoreService<T>
    {
        public SerializationSaveRestoreService(ISerializer<T> serializer)
            : base(serializer)
        { }

        public void Save(T o)
        {
            Serializer.Serialize(o);
        }

        public T Restore()
        {
            return Serializer.Deserialize();
        }
    }
}
