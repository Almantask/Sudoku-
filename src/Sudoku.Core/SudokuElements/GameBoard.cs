using Sudoku.Core.Rules;
using System.Collections.Generic;

namespace Sudoku.Core.SudokuElements
{
    public class GameBoard
    {
        private SudokuElementSolution[] _rows;
        private SudokuElementSolution[] _columns;
        private SudokuElementSolution[,] _squares;

        public int[,] Cells;

        public GameBoard()
        {
            Cells = new int[Game.SudokuSize, Game.SudokuSize];
            BuildSolutionElements();
            BuildBoardElements();
        }

        public GameBoard(int[,] cells)
        {
            CopyCells(cells);
            BuildSolutionElements();
            BuildBoardElements();
        }

        private void CopyCells(int[,] cells)
        {
            Cells = new int[Game.SudokuSize, Game.SudokuSize];
            for (var x = 0; x < Game.SudokuSize; x++)
            {
                for (var y = 0; y < Game.SudokuSize; y++)
                {
                    Cells[x, y] = cells[x, y];
                }
            }
        }

        private void BuildSolutionElements()
        {
            _rows = new SudokuElementSolution[Game.SudokuSize];
            _columns = new SudokuElementSolution[Game.SudokuSize];
            const int squareSize = 3;
            var squaresCount = Game.SudokuSize / squareSize;
            _squares = new SudokuElementSolution[squaresCount, squaresCount];
        }

        private void BuildBoardElements()
        {
            BuildRowsAndColumns();
            BuildSquares();
            RemoveUsedPossibilities();
        }

        private void RemoveUsedPossibilities()
        {
            for (var x = 0; x < Game.SudokuSize; x++)
            {
                for (var y = 0; y < Game.SudokuSize; y++)
                {
                    var cellValue = Cells[x, y];
                    if (cellValue != SudokuElementSolution.InvalidValue)
                    {
                        var elementsAtCell = GetSudokuElementsAtCell(x, y);
                        SudokuElementSolution.RemovePossibility(elementsAtCell, cellValue);
                    }
                }
            }
        }

        public bool IsCellFilled(int x, int y)
        {
            var cellValue = Cells[x, y];
            return cellValue != SudokuElementSolution.InvalidValue;
        }

        private void BuildRowsAndColumns()
        {
            for (var i = 0; i < Game.SudokuSize; i++)
            {
                _rows[i] = new SudokuElementSolution();
                _columns[i] = new SudokuElementSolution();
            }
        }



        private void BuildSquares()
        {
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    _squares[x,y] = new SudokuElementSolution();
                }
            }
        }

        public List<SudokuElementSolution> GetSudokuElementsAtCell(int x, int y)
        {
            return new List<SudokuElementSolution>()
            {
                GetSquare(x, y),
                _rows[y],
                _columns[x]
            };
        }

        private SudokuElementSolution GetSquare(int x, int y)
        {
            var squareX = x / 3;
            var squareY = y / 3;
            return _squares[squareX,squareY];
        }
    }
}
