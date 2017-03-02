using System;

namespace School.Common.Utils.Extensions
{
    public static class AttributeExtensions
    {
        public static T GetAttribute<T>(this Type t) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(t, typeof(T));
        }
    }
}
