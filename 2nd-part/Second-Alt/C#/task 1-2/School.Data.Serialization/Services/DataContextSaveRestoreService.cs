using System;
using School.Data.Serialization.Entity;
using School.Data.Serialization.Interfaces;

namespace School.Data.Serialization.Services
{
    internal sealed class DataContextSaveRestoreService : IDisposable
    {
        private readonly ISaveRestoreService<DataContext> _service;

        public DataContextSaveRestoreService(ISaveRestoreService<DataContext> service)
        {
            _service = service;
        }

        public void Save(DataContext context)
        {
            _service.Save(context);
        }

        public DataContext Restore()
        {
            DataContext context;

            try
            {
                context = _service.Restore();
            }
            catch (Exception)
            {
                context = new DataContext();
                context.MockData();
            }

            context.InitNavigationProperties();
            return context;
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
