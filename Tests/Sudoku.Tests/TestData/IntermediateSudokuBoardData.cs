﻿using Sudoku.Core.Rules;
using System.Collections.Generic;

namespace Tests.TestData
{
    internal class IntermediateSudokuBoardData: SudokuSolutionsTestData
    {
        public IntermediateSudokuBoardData()
        {
            _data = new List<object[]>
            {
                new object[]
                {
                    new int[,]
                    {
                        {0, 2, 0, 6, 0, 8, 0, 0, 0},
                        {5, 8, 0, 0, 0, 9, 7, 0, 0},
                        {0, 0, 0, 0, 4, 0, 0, 0, 0},
                        {3, 7, 0, 0, 0, 0, 5, 0, 0},
                        {6, 0, 0, 0, 0, 0, 0, 0, 4},
                        {0, 0, 8, 0, 0, 0, 0, 1, 3},
                        {0, 0, 0, 0, 2, 0, 0, 0, 0},
                        {0, 0, 9, 8, 0, 0, 0, 3, 6},
                        {0, 0, 0, 3, 0, 6, 0, 9, 0}
                    }
                }
            };
        }
    }
}
