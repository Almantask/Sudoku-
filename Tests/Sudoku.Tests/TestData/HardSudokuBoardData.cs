﻿using Sudoku.Core.Rules;
using System.Collections.Generic;

namespace Tests.TestData
{
    internal class HardSudokuBoardData : SudokuSolutionsTestData
    {
        public HardSudokuBoardData()
        {
            _data = new List<object[]>
            {
                new object[]
                {
                    new int[,]
                    {
                        {0, 0, 0, 6, 0, 0, 4, 0, 0},
                        {7, 0, 0, 0, 0, 3, 6, 0, 0},
                        {0, 0, 0, 0, 9, 1, 0, 8, 0},
                        {0, 0, 0, 0, 0, 0, 0, 0, 0},
                        {0, 5, 0, 1, 8, 0, 0, 0, 3},
                        {0, 0, 0, 3, 0, 6, 0, 4, 5},
                        {0, 4, 0, 2, 0, 0, 0, 6, 0},
                        {9, 0, 3, 0, 0, 0, 0, 0, 0},
                        {0, 2, 0, 0, 0, 0, 1, 0, 0}
                    }
                }
            };
        }
    }
}
