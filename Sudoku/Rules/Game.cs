using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sudoku.SudokuElements;

namespace Sudoku.Rules
{
    public class Game
    {
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
                return true && !tmpGame.UnsolvedCells.Any();
            }
            catch
            {
                return false;
            }
        }

        private void BuildUnsolvedCells()
        {
            UnsolvedCells = new List<Cell>();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if(Board.IsCellNotFilled(x, y))
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
                if (cellSolution == SudokuElementSolution.INVALID_VALUE) continue;
                solvedCells.Add(cell);
                Board.Cells[cell.X, cell.Y] = cellSolution;
                SudokuElementSolution.RemovePossibility(elements, cellSolution);
            }
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
