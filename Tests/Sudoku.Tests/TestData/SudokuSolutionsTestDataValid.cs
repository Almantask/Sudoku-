using Sudoku.Core.SudokuElements;
using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsTestDataValid : SudokuSolutionsTestData
    {
        public SudokuSolutionsTestDataValid()
        {
            _data = new List<object[]>
            {
                new object[] { new SudokuElementSolution(1), new SudokuElementSolution(1), new SudokuElementSolution(1)},
                new object[] { new SudokuElementSolution(1, 2, 3), new SudokuElementSolution(3, 4, 5), new SudokuElementSolution(3, 6, 7)},
            };
        }
    }
}