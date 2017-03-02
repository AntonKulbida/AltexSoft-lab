using System;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;

namespace School.Common.Utils.Extensions
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse(value, true, out result) ? result : defaultValue;
        }

        public static string ToCamelCase(this string str, CultureInfo culture = null)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return String.Empty;
            }

            culture = culture ?? CultureInfo.CurrentCulture;
            var strTitleCase = culture.TextInfo.ToTitleCase(str.Trim());

            return Regex.Replace(strTitleCase, "[^a-zA-Z0-9_]+", String.Empty, RegexOptions.Compiled);
        }

        public static string GetStringByKey(this string key, Type resourceSource, CultureInfo culture = null)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            culture = culture ?? CultureInfo.CurrentCulture;

            var resourceManager = new ResourceManager(resourceSource);
            return resourceManager.GetString(key, culture);
        }
    }
}
