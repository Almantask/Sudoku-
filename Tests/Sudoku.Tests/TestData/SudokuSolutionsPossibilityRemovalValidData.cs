using Sudoku.Core.SudokuElements;
using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsPossibilityRemovalValidData:SudokuSolutionsTestData
    {
        public SudokuSolutionsPossibilityRemovalValidData()
        {
            _data = new List<object[]>
            {
                new object[] {new SudokuElementSolution(1), new SudokuElementSolution(1), new SudokuElementSolution(1), 1},
                new object[] { new SudokuElementSolution(1, 2, 3), new SudokuElementSolution(3, 4, 5), new SudokuElementSolution(3, 6, 7), 3}
            };
        }
    }

    public class SudokuSolutionsPossibilityRemovalInvalidData : SudokuSolutionsTestData
    {
        public SudokuSolutionsPossibilityRemovalInvalidData()
        {
            _data = new List<object[]>
            {
                new object[] { new SudokuElementSolution(9), new SudokuElementSolution(8), new SudokuElementSolution(7), 2},
                new object[] { new SudokuElementSolution(2), new SudokuElementSolution(3), new SudokuElementSolution(4), 3},
                new object[] { new SudokuElementSolution(1, 2, 3), new SudokuElementSolution(4, 5, 6), new SudokuElementSolution(7, 8, 9), 0},
            };
        }
    }
}