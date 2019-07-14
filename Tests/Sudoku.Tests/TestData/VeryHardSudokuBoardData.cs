using Sudoku.Core.Rules;
using System.Collections.Generic;

namespace Tests.TestData
{
    internal class VeryHardSudokuBoardData : SudokuSolutionsTestData
    {
        public VeryHardSudokuBoardData()
        {
            _data = new List<object[]>
            {
                new object[]
                {
                    new int[Game.SudokuSize, Game.SudokuSize]
                    {
                        {0, 2, 0, 0, 0, 0, 0, 0, 0},
                        {0, 0, 0, 6, 0, 0, 0, 0, 3},
                        {0, 7, 4, 0, 8, 0, 0, 0, 0},
                        {0, 0, 0, 0, 0, 3, 0, 0, 2},
                        {0, 8, 0, 0, 4, 0, 0, 1, 0},
                        {6, 0, 0, 5, 0, 0, 0, 0, 0},
                        {0, 0, 0, 0, 1, 0, 7, 8, 0},
                        {5, 0, 0, 0, 0, 9, 0, 0, 0},
                        {0, 0, 0, 0, 0, 0, 0, 4, 0}
                    }
                }
            };
        }
    }
}
