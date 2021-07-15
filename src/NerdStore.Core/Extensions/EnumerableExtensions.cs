using System;
using System.Collections.Generic;

namespace NerdStore.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> itemAction )
        {
            foreach (var item in list)
            {
                itemAction(item);
            }
        }
    }
}
