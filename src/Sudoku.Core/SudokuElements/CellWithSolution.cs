using System.Collections.Generic;

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
