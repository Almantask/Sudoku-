using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuView.Data
{
    public static class Sudokus
    {
        public static int[,] EasySudoku =
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
            };
    }
}
