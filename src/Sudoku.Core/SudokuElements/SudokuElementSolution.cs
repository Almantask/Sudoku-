using Sudoku.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Core.SudokuElements
{
    /// <summary>
    /// Each element is made up from numbers 1-9. Those numbers indicate possibilities.
    /// Square (3x3), Row(1x9) or Column(9x1).
    /// </summary>
    public class SudokuElementSolution: ICloneable<SudokuElementSolution>
    {
        public const int InvalidValue = 0;

        private List<int> _possibilities;

        /// <summary>
        /// Sudoku element with all possibilities (1-9).
        /// </summary>
        public SudokuElementSolution()
        {
            _possibilities = new List<int>
            {
                1,2,3,4,5,6,7,8,9
            };
        }

        /// <summary>
        /// Sudoku element with given possibilities left.  
        /// </summary>
        public SudokuElementSolution(params int[] possibilities)
        {
            _possibilities = new List<int>();
            _possibilities.AddRange(possibilities);
        }

        public void RemovePossibility(int value)
        {
            if (_possibilities.Contains(value))
            {
                _possibilities.Remove(value);
            }
            else
            {
                throw new WrongSudokuMapException();
            }
        }

        public IEnumerable<int> GetPossibilities()
        {
            if (_possibilities.Any())
            {
                return _possibilities;
            }
            return new List<int>{0};
        }

        /// <summary>
        /// Gets intersection of the 3 sudoku elements.
        /// </summary>
        public static IEnumerable<int> GetValidValues(IList<SudokuElementSolution> elementsCollection)
        {
            var validValues = elementsCollection[0].GetPossibilities();
            for (int i = 1; i < elementsCollection.Count(); i++)
            {
                validValues = validValues.Intersect(elementsCollection[i].GetPossibilities());
            }

            return validValues;
        }

        /// <summary>
        /// Updates each sudoku elements' list of possibilities.
        /// </summary>
        public static void RemovePossibility(IEnumerable<SudokuElementSolution> elementsCollection, int possibility)
        {
            foreach (var elements in elementsCollection)
            {
                elements.RemovePossibility(possibility);
            }
        }

        public SudokuElementSolution Clone()
        {
            var clonedSolution = MemberwiseClone() as SudokuElementSolution;
            var possibilities = new int[_possibilities.Count];
            _possibilities.CopyTo(possibilities);
            clonedSolution._possibilities = possibilities.ToList();

            return clonedSolution;
        }
    }
}
