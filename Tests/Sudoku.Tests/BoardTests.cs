﻿using System;
using Sudoku.Core.Rules;
using Sudoku.Core.SudokuElements;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class BoardTests
    {
        [Fact]
        [Trait("Category", "Board Setup")]
        public void Get_Elements_Ok()
        {
            var board = new GameBoard();
            AcccessEachElementOneByOne(board);
        }

        private void AcccessEachElementOneByOne(GameBoard board)
        {
            for (var x = 0; x < Game.SudokuSize; x++)
            {
                for (var y = 0; y < Game.SudokuSize; y++)
                {
                    try
                    {
                        board.GetSudokuElementsAtCell(x, y);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"At ({x},{y}):" + ex.Message);
                    }
                }
            }
        }

        [Fact]
        [Trait("Category", "Board Setup")]
        public void Cell_Filled_Ok()
        {
            var cellMapp = new int[Game.SudokuSize, Game.SudokuSize];
            const int theOnlyFilledX = 0;
            const int theOnlyFilledY = 0;
            const int filledIntValue = 5;
            cellMapp[theOnlyFilledX, theOnlyFilledY] = filledIntValue;
            var board = new GameBoard(cellMapp);

            Assert.True(board.IsCellFilled(0, 0));
            Assert.False(board.IsCellFilled(0, 1));
        }

        [Theory]
        [Trait("Category", "Board Setup")]
        [ClassData(typeof(EasySudokuBoardData))]
        public void Create_Board_Ok(int[,] cells)
        {
            var isSuccess = true;
            var message = "";
            try
            {
                var board = new GameBoard(cells);
            }
            catch(Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }
            Assert.True(isSuccess, message);
        }
    }
}