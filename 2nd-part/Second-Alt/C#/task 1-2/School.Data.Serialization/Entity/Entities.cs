using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using School.Common.Utils.Extensions;
using School.Data.Entity.Models;
using School.Data.Interfaces;
using School.Data.Serialization.Services;

namespace School.Data.Serialization.Entity
{
    internal sealed class Entities : IEntitiesContext
    {
        private DataContext _context;
        private readonly DataContextSaveRestoreService _service;

        public Entities(DataContextSaveRestoreService service)
        {
            _service = service;
            LoadContext();

            _context.Students.CollectionChanged += OnStudentsChanged;
            _context.Teachers.CollectionChanged += OnTeachersChanged;
        }

        public IList<Student> Students { get { return _context.Students; } }

        public IList<Teacher> Teachers { get { return _context.Teachers; } }

        public void SaveChanges()
        {
            _service.Save(_context);
        }

        public void Dispose()
        {
            _context.Students.CollectionChanged -= OnStudentsChanged;
            _context.Teachers.CollectionChanged -= OnTeachersChanged;

            _service.Dispose();
        }

        private void LoadContext()
        {
            _context = _service.Restore();
        }

        private void OnStudentsChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            var changedItems = (args.NewItems ?? args.OldItems).OfType<Student>().Where(s => s.Teacher != null);
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    changedItems.ForEach(s => s.Teacher.Students = s.Teacher.Students.Except(s.ToEnumerable()).ToArray());
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Reset:
                    changedItems.ForEach(s =>
                    {
                        if (s.Teacher.Students.Contains(s))
                            return;

                        s.Teacher.Students = s.Teacher.Students.Concat(s.ToEnumerable()).ToArray();
                    });
                    break;
            }
        }

        private void OnTeachersChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            var changedItems = (args.NewItems ?? args.OldItems).OfType<Teacher>();
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    changedItems.ForEach(t => t.Students.ForEach(s => s.Teacher = null));
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Reset:
                    changedItems.ForEach(t => t.Students.ForEach(s => s.Teacher = t));
                    break;
            }
        }
    }
}
