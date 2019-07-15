using System;

namespace Sudoku.Core.Exceptions
{
    public class UnsolvableSudokuException: Exception
    {
        public UnsolvableSudokuException(): base("Ran out of options.")
        {
        }
    }
}
