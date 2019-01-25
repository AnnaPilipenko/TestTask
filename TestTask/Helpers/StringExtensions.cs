using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Helpers
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comparison)
        {
            return source?.IndexOf(toCheck, comparison) >= 0;
        }
    }
}