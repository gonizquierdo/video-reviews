using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoReviews.Utils
{
    public static class Helpers
    {
        public static IList<IList<T>> TakeBy<T>(this IEnumerable<T> list, int takeBy)
        {
            IList<IList<T>> result = new List<IList<T>>();

            int count = 0;
            foreach (var item in list)
            {
                if (count == 0)
                {
                    result.Add(new List<T>());
                }
                var current = result.LastOrDefault();
                current.Add(item);
                count++;
                if (count == takeBy)
                {
                    count = 0;
                }
            }

            return result;
        }
    }
}