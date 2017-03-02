using System;
using School.Common.Core;

namespace School.Data.Entity.Models.BaseEntities
{
    [Serializable]
    public class Person : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public Person()
        {
            Id = -1;
        }

        public override string ToString()
        {
            return String.Format(Strings.PersonToStringFormat, base.ToString(), FirstName, LastName);
        }
    }
}
