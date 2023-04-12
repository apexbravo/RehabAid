using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RehabAid.Lib
{
    public static class LibExtensions
    {
        public static string Initials(this string name)
        {
            var firstChars = (name.Trim().IndexOf(" ") == -1 ?
        name.Substring(0, Math.Min(2, name.Length)) :
        new string(name.Trim().Split(" ").Where(c => !string.IsNullOrWhiteSpace(c)).Select(c => c[0]).Take(2).ToArray())).ToUpper();

            return string.Join("", firstChars).ToUpper();
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static bool Rights(this int value)
        {

            return true;
        }
        public static bool IsSameDay(this DateTime datetime1, DateTime datetime2)
        {
            return datetime1.Year == datetime2.Year
                && datetime1.Month == datetime2.Month
                && datetime1.Day == datetime2.Day;
        }
        public static HtmlString ToHtmlString(this bool value)
=> new HtmlString($"<i class='fa fa-{(value ? "check-circle text-success" : "times-circle text-muted")}'></i>");
    
}
}
