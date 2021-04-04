using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcheWay_Site.App_Code
{
    public static class Utils
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return !(list?.Any() ?? false);
        }
    }
}