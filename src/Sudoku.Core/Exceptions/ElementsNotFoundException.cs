using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.Exceptions
{
    public class SudokuElementsNotFoundException:Exception
    {
        public SudokuElementsNotFoundException(int x, int y, string reason): base($"At ({x},{y}), reason: {reason}")
        {
        }
    }
}
