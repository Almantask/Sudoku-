using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Rules;
using Sudoku.SudokuElements;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class BoardTests
    {
        [Fact]
        public void TestGetElements()
        {
            var board = new GameBoard();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    try
                    {
                        board.GetSudokuElementsAtCell(0, 0);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"At ({x},{y}):" + ex.Message);
                    }
                }
            }
        }

        [Fact]
        public void TestCellFilled()
        {
            int[,] cellMapp = new int[9, 9];
            cellMapp[0, 0] = 5;
            var board = new GameBoard(cellMapp);
            Assert.False(board.IsCellNotFilled(0, 0));
            Assert.True(board.IsCellNotFilled(0, 1));
        }

        [Theory]
        [ClassData(typeof(SudokuBoardData))]
        public void TestCreateBoard(int[,] cells)
        {
            bool isSuccess = true;
            try
            {
                var board = new GameBoard(cells);
            }
            catch
            {
                isSuccess = false;
            }
            Assert.True(isSuccess);
        }
    }
}
