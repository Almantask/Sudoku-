using Sudoku.Core.Rules;
using Tests.TestData;
using Xunit;

namespace Tests
{

    public class GameTests
    {
        [Theory]
        [Trait("Category", "Board Setup")]
        [ClassData(typeof(SudokuGameSetupData))]
        public void SolutionPrepare_Ok(int [,] cells, int emptyCellsCount)
        {
            var game = new Game(cells);
            Assert.Equal(emptyCellsCount, game.UnsolvedCells.Count);
        }

        [Theory]
        [Trait("Category", "Solve game")]
        [ClassData(typeof(EasySudokuBoardData))]
        [ClassData(typeof(IntermediateSudokuBoardData))]
        [ClassData(typeof(HardSudokuBoardData))]
        [ClassData(typeof(VeryHardSudokuBoardData))]
        public void Solve_Ok(int[,] cells)
        {
            var game = new Game(cells);
            game.Solve();
            Assert.True(game.IsComplete());
        }
    }
}
