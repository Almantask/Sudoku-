using Sudoku.Core.Exceptions;
using Sudoku.Core.Extensions;
using Sudoku.Core.Rules;
using Sudoku.Core.SudokuElements;
using Sudoku.Core.SudokuGenerator;

namespace Sudoku.Core
{
    public class Generator
    {
        public int[,] Generate(int hidden)
        {
            ValidateHiddenAmount(hidden);

            var game = new RandomGame();
            var solution = game.Solve();
            var cells = solution.Board.CellsSolution;
            HideRandomly(hidden, cells);

            return cells;
        }

        private void ValidateHiddenAmount(int hidden)
        {
            const int minHiddenCount = 1;
            if (hidden < minHiddenCount || hidden >= Game.SudokuSize * Game.SudokuSize)
            {
                throw new InvalidHiddenCellsCountException(hidden);
            }

        }

        private void HideRandomly(int count, int[,] cells)
        {
            var indexes = CollectionExtensions.CreateIndexesFromZeroToCount(Game.SudokuSize*Game.SudokuSize);
            for(var i = 0; i < count; i++)
            {
                var index = CollectionExtensions.PickRandomIndex(indexes);
                indexes.Remove(index);

                var cell = ToCell(index);
                cells[cell.Y, cell.X] = 0;
            }
        }

        private static Cell ToCell(int index)
        {
            var row = index / Game.SudokuSize;
            var column = index - row * Game.SudokuSize;

            return new Cell(column, row);
        }
    }
}
