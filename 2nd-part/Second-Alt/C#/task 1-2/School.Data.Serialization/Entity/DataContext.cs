using System;
using System.Collections.ObjectModel;
using System.Linq;
using School.Common.Utils.Extensions;
using School.Data.Entity.Models;

namespace School.Data.Serialization.Entity
{
    [Serializable]
    public sealed class DataContext
    {
        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<Teacher> Teachers { get; set; }

        public void InitNavigationProperties()
        {
            Students
                .Join(Teachers, s => s.TeacherId, t => t.Id, (s, t) => new { Student = s, Teacher = t })
                .ForEach(st => st.Student.Teacher = st.Teacher);

            Students
                .Where(s => s.Teacher != null)
                .GroupBy(s => s.Teacher)
                .ForEach(gr => gr.Key.Students = gr.ToArray());
        }

        #region Mock Data

        public void MockData()
        {
            var teachers = new ObservableCollection<Teacher>
            {
                new Teacher {Id = 1, Age = 35, FirstName = "John", LastName = "Doe"},
                new Teacher {Id = 2, Age = 27, FirstName = "Mat", LastName = "Vaniah"},
                new Teacher {Id = 3, Age = 45, FirstName = "Will", LastName = "Smith"}
            };

            var students = new ObservableCollection<Student>
            {
                new Student {Id = 1, Age = 12, FirstName = "Skandar", LastName = "Keynes", TeacherId = 1},
                new Student {Id = 2, Age = 11, FirstName = "Dakota", LastName = "Fanning", TeacherId = 1},
                new Student {Id = 3, Age = 13, FirstName = "Armie", LastName = "Hammer", TeacherId = 2},
                new Student {Id = 4, Age = 12, FirstName = "Thomas", LastName = "Dekker", TeacherId = 2},
                new Student {Id = 5, Age = 16, FirstName = "Emma", LastName = "Watson", TeacherId = 2},
                new Student {Id = 6, Age = 15, FirstName = "Taylor", LastName = "Lautner", TeacherId = 3},
                new Student {Id = 7, Age = 15, FirstName = "Robert", LastName = "Sheehan", TeacherId = 3},
                new Student {Id = 8, Age = 12, FirstName = "Lucas", LastName = "Grabeel", TeacherId = 3},
            };

            Students = students;
            Teachers = teachers;
        }

        #endregion
    }
}
