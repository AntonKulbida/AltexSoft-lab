using System;

namespace School.Common.Serialization.Interfaces
{
    public interface ISerializer<T> : IDisposable
    {
        void Serialize(T o);

        T Deserialize();
    }
}