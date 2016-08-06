using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS.Layer.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static void DeleteMissing<T, R>(this ICollection<R> collection2, IEnumerable<T> collection1,
          Func<T, R, bool> matchingFunc) where T : class
        {
            foreach (var item in collection2.ToList())
            {
                var matching = collection1.FirstOrDefault(i => matchingFunc(i, item));
                if (matching == null)
                    collection2.Remove(item);
            }
        }
    }
}
