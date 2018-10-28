using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.TestData
{
    class SudokuBoardData: SudokuSolutionsTestData
    {
        public SudokuBoardData()
        {
            _data = new List<object[]>
            {
                new object[]
                {
                    new int[9, 9]
                    {
                        {0, 4, 9, 8, 0, 6, 0, 7, 0},
                        {0, 2, 0, 0, 4, 7, 9, 0, 6},
                        {0, 7, 3, 0, 0, 1, 2, 0, 8},
                        {3, 0, 6, 0, 0, 0, 7, 2, 4},
                        {7, 0, 0, 4, 3, 9, 0, 8, 0},
                        {4, 0, 8, 7, 0, 2, 0, 0, 9},
                        {0, 0, 7, 9, 1, 0, 8, 6, 0},
                        {2, 8, 0, 0, 7, 0, 0, 9, 5},
                        {9, 6, 0, 2, 5, 0, 4, 0, 0}
                    }
                }

            };
        }
    }
}
