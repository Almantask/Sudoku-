using System;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Rules;

namespace Sudoku.SudokuElements
{
    public class SudokuElementSolution
    {
        public const int INVALID_VALUE = 0;

        private readonly List<int> _possibilities;

        public SudokuElementSolution()
        {
            _possibilities = new List<int>
            {
                1,2,3,4,5,6,7,8,9
            };
        }

        public SudokuElementSolution(params int[] possibilities)
        {
            _possibilities = new List<int>();
            foreach (var possibility in possibilities)
            {
                _possibilities.Add(possibility);
            }
        }

        public void RemovePossibility(int value)
        {
            if(_possibilities.Contains(value))
                _possibilities.Remove(value);
            else
            {
                throw new Exception("Wrong sudoku map");
            }
        }

        public IEnumerable<int> GetPossibilities()
        {
            if(_possibilities.Any())
            return _possibilities;
            return new List<int>() {0};
        }

        public static int GetUniqueCellSolution(IList<SudokuElementSolution> elementsCollection)
        {
            var validValues = GetValidValues(elementsCollection);
            if (validValues.Count() > 1)
                return INVALID_VALUE;
            return validValues.FirstOrDefault();
        }

        public static IEnumerable<int> GetValidValues(IList<SudokuElementSolution> elementsCollection)
        {
            var validValues = elementsCollection.FirstOrDefault().GetPossibilities();
            for (int i = 1; i < elementsCollection.Count(); i++)
            {
                validValues = validValues.Intersect(elementsCollection[i].GetPossibilities());
            }

            return validValues;
        }

        public static void RemovePossibility(IEnumerable<SudokuElementSolution> elementsCollection, int possibility)
        {
            foreach (var elements in elementsCollection)
            {
                elements.RemovePossibility(possibility);
            }
        }
    }
}
