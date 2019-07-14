using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Sudoku.Tests")]
namespace Sudoku.Core.Extensions
{
    internal static class CollectionExtensions
    {
        private static Random _random = new Random();

        public static IList<T> Shuffle<T>(this IList<T> collection)
        {
            var possibilities = CreateIndexesFromZeroToCount(collection.Count());
            var shuffled = new List<T>();

            while(possibilities.Any())
            {
                var index = PickRandomIndex(possibilities);
                possibilities.Remove(index);
                shuffled.Add(collection[index]);
            }

            return shuffled;
        }

        public static IList<int> CreateIndexesFromZeroToCount(int count)
        {
            var list = new List<int>();
            for(var i = 0; i < count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        public static int PickRandomIndex(IList<int> possibleIndexs)
        {
            var index = _random.Next(possibleIndexs.Count());

            return possibleIndexs[index];
        }
    }
}
