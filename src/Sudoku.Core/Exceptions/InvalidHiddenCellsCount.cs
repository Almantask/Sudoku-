using Sudoku.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.Exceptions
{
    public class InvalidHiddenCellsCountException: Exception
    {
        public InvalidHiddenCellsCountException(int provided) : 
            base($"Max cells: {Game.SudokuSize * Game.SudokuSize}, provided: {provided}"){ }
    }
}
