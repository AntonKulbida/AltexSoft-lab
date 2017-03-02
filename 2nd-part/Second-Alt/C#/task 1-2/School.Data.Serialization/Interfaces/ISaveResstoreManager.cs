using System;

namespace School.Data.Serialization.Interfaces
{
    internal interface ISaveRestoreService<T> : IDisposable
    {
        void Save(T o);

        T Restore();
    }
}
