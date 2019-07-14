using Sudoku.Core.Rules;

namespace Sudoku.Core.Extensions
{
    internal static class Array2DExtensions
    {
        public static T[,] CloneElements<T>(this T[,] array)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            var clone = new T[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    clone[row, column] = array[row, column];
                }
            }

            return clone;
        }

        public static T[,] CloneElementsDeep<T>(this T[,] array) where T : ICloneable<T>
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            var clone = new T[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    clone[row, column] = array[row, column].Clone();
                }
            }

            return clone;
        }
    }
}
