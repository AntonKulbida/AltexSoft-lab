using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using School.Data.Entity.Models.BaseEntities;

namespace School.Data.Entity.Models
{
    [Serializable]
    public sealed class Teacher : Person
    {
        [XmlIgnore]
        public ICollection<Student> Students { get; set; }

        public Teacher()
        {
            Students = new List<Student>();
        }
    }
}
