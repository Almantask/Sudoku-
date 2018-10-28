using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sudoku.SudokuElements
{
    public class GameBoard
    {
        private SudokuElementSolution[] _rows;
        private SudokuElementSolution[] _columns;
        private SudokuElementSolution[,] _squares;

        public int[,] Cells;

        public GameBoard()
        {
            Cells = new int[9, 9];
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
            Cells = new int[9,9];
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Cells[x, y] = cells[x, y];
                }
            }
        }

        private void BuildSolutionElements()
        {
            _rows = new SudokuElementSolution[9];
            _columns = new SudokuElementSolution[9];
            _squares = new SudokuElementSolution[3, 3];
        }

        private void BuildBoardElements()
        {
            BuildRowsAndColumns();
            BuildSquares();
            RemoveUsedPossibilities();
        }

        private void RemoveUsedPossibilities()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    var cellValue = Cells[x, y];
                    if (cellValue != SudokuElementSolution.INVALID_VALUE)
                    {
                        var elementsAtCell = GetSudokuElementsAtCell(x, y);
                        SudokuElementSolution.RemovePossibility(elementsAtCell, cellValue);
                    }
                }
            }
        }

        public bool IsCellNotFilled(int x, int y)
        {
            var cellValue = Cells[x, y];
            return cellValue == SudokuElementSolution.INVALID_VALUE;
        }

        private void BuildRowsAndColumns()
        {
            for (int i = 0; i < 9; i++)
            {
                _rows[i] = new SudokuElementSolution();
                _columns[i] = new SudokuElementSolution();
            }
        }



        private void BuildSquares()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
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
