using System;
using System.Xml.Serialization;
using School.Data.Interfaces;

namespace School.Data.Entity.Models.BaseEntities
{
    [Serializable]
    public abstract class Entity<T> : IEntity<T> where T : struct
    {
        [XmlAttribute]
        public T Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

            var entity = (Entity<T>) obj;
            return Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return String.Format("{0} - {1}", GetType().FullName, Id).GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
