using Sudoku.Core.Rules;
using System;

namespace Sudoku.Core.Extensions
{
    internal static class Array2DExtensions
    {
        public static T[,] Copy<T>(this T[,] array) => Map(array, Copy);
        public static T[,] DeepClone<T>(this T[,] array) where T : ICloneable<T> => Map(array, Clone);

        private static T Copy<T>(T element) => element;
        private static T Clone<T>(T element) where T : ICloneable<T> => element.Clone();

        private static T[,] Map<T>(this T[,] array, Func<T,T> Mapper)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            var clone = new T[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    clone[row, column] = Mapper(array[row, column]);
                }
            }

            return clone;
        }
    }
}
