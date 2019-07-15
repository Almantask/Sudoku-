using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Sudoku.Tests")]
namespace Sudoku.Core.SudokuElements
{
    internal struct CellWithSolutions
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
