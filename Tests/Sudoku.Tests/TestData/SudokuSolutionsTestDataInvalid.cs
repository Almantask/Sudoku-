using Sudoku.Core.SudokuElements;
using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsTestDataInvalid : SudokuSolutionsTestData
    {

        public SudokuSolutionsTestDataInvalid()
        {
            _data = new List<object[]>
            {
                new object[] { new SudokuElementSolution(1,2,3), new SudokuElementSolution(4,5,6), new SudokuElementSolution(7,8,9)},
                new object[] { new SudokuElementSolution(2), new SudokuElementSolution(3), new SudokuElementSolution(4)},
                new object[] { new SudokuElementSolution(), new SudokuElementSolution(), new SudokuElementSolution()},
                new object[] { new SudokuElementSolution(), new SudokuElementSolution(1), new SudokuElementSolution(2)},
                new object[] { new SudokuElementSolution(), new SudokuElementSolution(0), new SudokuElementSolution(2) }
            };
        }
    }
}