using Sudoku.Core.Exceptions;
using Sudoku.Core.Extensions;
using Sudoku.Core.SudokuElements;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Sudoku.Tests")]
namespace Sudoku.Core.Rules
{
    public class Game: ICloneable<Game>
    {
        public const int SudokuSize = 9;

        public IList<Cell> UnsolvedCells { get; private set; }

        public GameBoard Board { set; get; }

        public Game()
        {
            Board = new GameBoard();
            BuildUnsolvedCells();
        }

        public Game(int[,] filledCells)
        {
            Board = new GameBoard(filledCells);
            BuildUnsolvedCells();
        }

        internal bool IsComplete()
        {
            return !UnsolvedCells.Any();
        }

        private void BuildUnsolvedCells()
        {
            UnsolvedCells = new List<Cell>();
            for (int x = 0; x < SudokuSize; x++)
            {
                for (int y = 0; y < SudokuSize; y++)
                {
                    if (!Board.IsCellFilled(x, y))
                        UnsolvedCells.Add(new Cell(x, y));
                }
            }
        }

        /// <summary>
        /// Returns a snapshot of a solved Sudoku.
        /// </summary>
        /// <returns></returns>
        public Game Solve()
        {
            try
            {
                Solve(this);
            }
            // Huge workaround to escape recursion
            catch(SudokuCompletedException exection)
            {
                return exection.Game;
            }

            throw new UnsolvableSudokuException();
        }

        protected void Solve(Game game)
        {
            var result = game.FindCellWithLeastSolutions();
            if (!result.HasValue)
            {
                return;
            }

            var cellWithLeastSolutions = result.Value;
            var solutions = cellWithLeastSolutions.Solutions.Count();
            if (solutions == 1)
            {
                game.AssignGuess(cellWithLeastSolutions, cellWithLeastSolutions.Solutions.FirstOrDefault());
                if (game.IsComplete())
                {
                    throw new SudokuCompletedException(game);
                }
                Solve(game);
            }
            else
            {
                Guess(game, cellWithLeastSolutions);
            }
        }

        private protected virtual void Guess(Game game, CellWithSolutions cellWithLeastSolutions)
        {
            foreach (var guess in cellWithLeastSolutions.Solutions)
            {
                var gameSnapshot = game.Clone();
                gameSnapshot.AssignGuess(cellWithLeastSolutions, guess);
                Solve(gameSnapshot);
            }
        }

        internal void AssignGuess(CellWithSolutions cellWithLeastSolutions, int guess)
        {
            var cell = cellWithLeastSolutions.Cell;
            var elements = Board.GetSudokuElements(cell.X, cell.Y);
            SudokuElementSolution.RemovePossibility(elements, guess);
            Board.CellsSolution[cell.X, cell.Y] = guess;
            UnsolvedCells.Remove(cell);
        }

        internal CellWithSolutions? FindCellWithLeastSolutions()
        {
            var leastSolutions = 10;
            CellWithSolutions? cellWithLeastOptions = null;

            foreach (var cell in UnsolvedCells)
            {
                var elements = Board.GetSudokuElements(cell.X, cell.Y);
                var solutions = SudokuElementSolution.GetValidValues(elements);
                var count = solutions.Count();
                if (count < leastSolutions && count > 0)
                {
                    leastSolutions = count;
                    cellWithLeastOptions = new CellWithSolutions(cell, solutions);
                }
            }

            return cellWithLeastOptions;
        }

        public Game Clone()
        {
            var clonedGame = MemberwiseClone() as Game;
            var clonedBoard = Board.Clone() as GameBoard;
            clonedGame.Board = clonedBoard;
            clonedGame.UnsolvedCells = UnsolvedCells.ToArray().CloneElementsDeep().ToList();

            return clonedGame;
        }
    }
}
