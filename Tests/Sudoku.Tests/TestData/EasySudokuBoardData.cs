﻿using Sudoku.Core.Rules;
using System.Collections.Generic;

namespace Tests.TestData
{
    internal class EasySudokuBoardData: SudokuSolutionsTestData
    {
        public EasySudokuBoardData()
        {
            _data = new List<object[]>
            {
                new object[]
                {
                    new int[Game.SudokuSize, Game.SudokuSize]
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
                },
                new object[]
                {
                    new int[Game.SudokuSize, Game.SudokuSize]
                    {
                        {0, 0, 0, 2, 6, 0, 7, 0, 1},
                        {6, 8, 0, 0, 7, 0, 0, 9, 0},
                        {1, 9, 0, 0, 0, 4, 5, 0, 0},
                        {8, 2, 0, 1, 0, 0, 0, 4, 0},
                        {0, 0, 4, 6, 0, 2, 9, 0, 0},
                        {0, 5, 0, 0, 0, 3, 0, 2, 8},
                        {0, 0, 9, 3, 0, 0, 0, 7, 4},
                        {0, 4, 0, 0, 5, 0, 0, 3, 6},
                        {7, 0, 3, 0, 1, 8, 0, 0, 0}
                    }
                },
                new object[]
                {
                    new int[Game.SudokuSize, Game.SudokuSize]
                    {
                        {1, 0, 0, 4, 8, 9, 0, 0, 6},
                        {7, 3, 0, 0, 0, 0, 0, 4, 0},
                        {0, 0, 0, 0, 0, 1, 2, 9, 5},
                        {0, 0, 7, 1, 2, 0, 6, 0, 0},
                        {5, 0, 0, 7, 0, 3, 0, 0, 8},
                        {0, 0, 6, 0, 9, 5, 7, 0, 0},
                        {9, 1, 4, 6, 0, 0, 0, 0, 0},
                        {0, 2, 0, 0, 0, 0, 0, 3, 7},
                        {8, 0, 0, 5, 1, 2, 0, 0, 4}
                    }
                }
            };
        }
    }
}