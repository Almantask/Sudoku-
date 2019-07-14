using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.Exceptions
{
    public class UnsolvableSudokuException: Exception
    {
        public UnsolvableSudokuException(): base("Ran out of options.") { }
    }
}
