using Sudoku.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.Extensions
{
    public static class ArrayExtensions
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
