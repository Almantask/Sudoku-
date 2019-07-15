using Sudoku.Core.Rules;
using System.Collections.Generic;

namespace Tests.TestData
{
    class SudokuGameSetupData: SudokuSolutionsTestData
    {
        public SudokuGameSetupData()
        {
            _data = new List<object[]>
            {
                new object[]
                {
                    Sudoku.Benchmarks.TestData.EasySudokuBoardData.Cells,
                    36
                }

            };
        }
    }
}
