using System;
using System.Xml.Serialization;
using School.Data.Entity.Models.BaseEntities;

namespace School.Data.Entity.Models
{
    [Serializable]
    public sealed class Student : Person
    {
        private Teacher _teacher;

        [XmlIgnore]
        public Teacher Teacher
        {
            get { return _teacher; }
            set
            {
                if (_teacher != null && _teacher.Equals(value))
                    return;

                _teacher = value;
                TeacherId = _teacher != null ? _teacher.Id : (int?) null;
            }
        }

        public int? TeacherId { get; set; }

        public Student()
        {
            Teacher = null;
        }
    }
}
