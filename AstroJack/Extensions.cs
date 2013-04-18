using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroJack
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }


        public static string Truncate(this string value, int seed, int length)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            var jump = 11 - ((length+seed) - value.Length);
            if(jump < 0) return string.Empty;
            return value.Length <= length+seed ? value.Substring(seed, jump)  : value.Substring(seed, 11);
        }
    }
}
