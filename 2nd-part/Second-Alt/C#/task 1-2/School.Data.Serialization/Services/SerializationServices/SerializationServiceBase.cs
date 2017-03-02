using System;
using School.Common.Serialization.Interfaces;

namespace School.Data.Serialization.Services.SerializationServices
{
    internal class SerializationServiceBase<T> : IDisposable
    {
        protected readonly ISerializer<T> Serializer;

        protected SerializationServiceBase(ISerializer<T> serializer)
        {
            Serializer = serializer;
        }

        public void Dispose()
        {
            Serializer.Dispose();
        }
    }
}
