using System;
using System.Text.RegularExpressions;

namespace EServicesCommon.Common
{
    public static class Extensions
    {

        public static string ValidateName(this string str)
        {
            var newStr = Regex.Replace(str, "[^\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z0-9_ ]{1,100}", "", RegexOptions.Compiled);
            if (string.IsNullOrEmpty(newStr) || string.IsNullOrWhiteSpace(newStr)) newStr = Guid.NewGuid().ToString();
            return newStr;

        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

    }
}
