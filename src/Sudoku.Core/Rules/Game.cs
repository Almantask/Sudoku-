using System;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Core.SudokuElements;

namespace Sudoku.Core.Rules
{
    public class Game
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

        public bool IsComplete()
        {
            return !UnsolvedCells.Any();
        }

        public static bool IsFilledCorrectly(int[,] cells)
        {
            try
            {
                var tmpGame = new Game(cells);
                return !tmpGame.UnsolvedCells.Any();
            }
            catch
            {
                return false;
            }
        }

        private void BuildUnsolvedCells()
        {
            UnsolvedCells = new List<Cell>();
            for (int x = 0; x < SudokuSize; x++)
            {
                for (int y = 0; y < SudokuSize; y++)
                {
                    if(!Board.IsCellFilled(x, y))
                        UnsolvedCells.Add(new Cell(x, y));
                }
            }
        }

        public void Solve()
        {
            IList<Cell> solvedCells = new List<Cell>();
            foreach (var cell in UnsolvedCells)
            {
                var elements = Board.GetSudokuElementsAtCell(cell.X, cell.Y);
                var cellSolution = SudokuElementSolution.GetUniqueCellSolution(elements);
                if (cellSolution == SudokuElementSolution.InvalidValue) continue;

                solvedCells.Add(cell);
                Board.Cells[cell.X, cell.Y] = cellSolution;
                SudokuElementSolution.RemovePossibility(elements, cellSolution);
            }

            // Stuck
            if (!solvedCells.Any())
            {
                throw new Exception("Unsolvable sudoku: ran out of solutions");
            }

            UnsolvedCells = UnsolvedCells.Except(solvedCells).ToList();
            if (UnsolvedCells.Any())
                Solve();
        }
    }
}
