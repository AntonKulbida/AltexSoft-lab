using System;
using System.Collections.Generic;

namespace School.Common.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if(collection == null)
                throw new ArgumentNullException("collection");

            if(action == null)
                throw new ArgumentNullException("action");

            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
