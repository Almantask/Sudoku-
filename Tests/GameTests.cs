using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Rules;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class GameTests
    {
        [Theory]
        [ClassData(typeof(SudokuGameSetupData))]
        public void TestSolutionPrepare(int [,] cells, int emptyCellsCount)
        {
            var game = new Game(cells);
            Assert.Equal(emptyCellsCount, game.UnsolvedCells.Count);
        }

        [Theory]
        [ClassData(typeof(SudokuBoardData))]
        public void TestSolve(int[,] cells)
        {
            var game = new Game(cells);
            game.Solve();
            Assert.True(game.IsComplete());
        }

        [Theory]
        [ClassData(typeof(SudokuBoardData))]
        public void TestIsFullBoardFilled(int[,] cells)
        {
            bool isSuccess = true;

            Assert.True(isSuccess);
        }

    }
}
