using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.SudokuElements
{
    public struct CellWithSolutions
    {
        public Cell Cell { get; }
        public IEnumerable<int> Solutions { get; }

        public CellWithSolutions(Cell cell, IEnumerable<int> solutions)
        {
            Cell = cell;
            Solutions = solutions;
        }
    }
}
