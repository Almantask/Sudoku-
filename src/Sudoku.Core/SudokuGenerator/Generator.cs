using Sudoku.Core.Exceptions;
using Sudoku.Core.Extensions;
using Sudoku.Core.Rules;
using Sudoku.Core.SudokuElements;
using Sudoku.Core.SudokuGenerator;

namespace Sudoku.Core
{
    public static class Generator
    {
        public const int MaxHiddenCount = Game.SudokuSize * Game.SudokuSize;
        public const int MinHiddenCount = 1;

        public static int[,] Generate(int hidden)
        {
            ValidateHiddenAmount(hidden);

            var game = new RandomGame();
            var solution = game.Solve();
            var cells = solution.Board.CellsSolution;
            HideRandomly(hidden, cells);

            return cells;
        }

        public static bool IsValidHiddenCount(int hidden) => hidden > MinHiddenCount && hidden < MaxHiddenCount;

        private static void ValidateHiddenAmount(int hidden)
        {
            if (!IsValidHiddenCount(hidden))
            {
                throw new InvalidHiddenCellsCountException(hidden);
            }

        }

        private static void HideRandomly(int count, int[,] cells)
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
