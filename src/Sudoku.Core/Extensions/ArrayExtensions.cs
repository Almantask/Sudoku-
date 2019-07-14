using Sudoku.Core.Rules;

namespace Sudoku.Core.Extensions
{
    internal static class ArrayExtensions
    {
        public static T[] CloneElementsDeep<T>(this T[] array) where T : ICloneable<T>
        {
            var count = array.Length;
            var clone = new T[count];

            for (var i = 0; i < count; i++)
            {
                clone[i] = array[i].Clone();
            }

            return clone;
        }
    }
}
