using System;
using System.Collections.Generic;
using System.Linq;
using School.Common.Core;
using School.Common.Utils.Extensions;
using School.Data.Entity.Models.BaseEntities;

namespace School.Operations.Helpers
{
    internal static class ConsoleHelpers
    {
        internal static T PickPerson<T>(this IEnumerable<T> persons, string message) where T : Person
        {
            var personsArray = persons as T[] ?? persons.ToArray();

            Console.WriteLine(message);

            while (true)
            {
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine(Strings.InvalidId);
                    continue;
                }

                var selectedPerson = personsArray.FirstOrDefault(p => p.Id == id);
                if (selectedPerson == null)
                {
                    Console.WriteLine(Strings.WrongId);
                    continue;
                }

                return selectedPerson;
            }
        }

        internal static void PrintPersonList(this IEnumerable<Person> persons, string message)
        {
            Console.WriteLine(message);

            persons.OrderBy(p => p.FirstName).ForEach(Console.WriteLine);
        }
    }
}
