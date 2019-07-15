using Sudoku.Core.Rules;

namespace Sudoku.Core.SudokuElements
{
    public struct Cell : ICloneable<Cell>
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cell Clone()
        {
            return (Cell)MemberwiseClone();
        }
    }
}
