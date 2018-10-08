using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelGen
{
    public static class ExtensionMethods
    {
        public static T PickOne<T>(this IEnumerable<T> col)
        {
            var enumerable = col as T[] ?? col.ToArray();
            return enumerable[Random.Range(0, enumerable.Count())];
        }
    }
}