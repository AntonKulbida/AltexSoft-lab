using System.Collections.Generic;

namespace School.Common.Utils.Extensions
{
    public static class GenericExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T value)
        {
            yield return value;
        }
    }
}
