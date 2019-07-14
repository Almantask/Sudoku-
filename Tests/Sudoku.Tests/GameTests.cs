using Sudoku.Core.Rules;
using System.Linq;
using Tests.TestData;
using Xunit;

namespace Sudoku.Tests
{
    public class GameTests
    {
        [Theory]
        [Trait("Category", "Board Setup")]
        [ClassData(typeof(SudokuGameSetupData))]
        public void SolutionPrepare_Ok(int[,] cells, int emptyCellsCount)
        {
            var game = new Game(cells);
            Assert.Equal(emptyCellsCount, game.UnsolvedCells.Count);
        }

        [Theory]
        [Trait("Category", "Solve game")]
        [ClassData(typeof(EasySudokuBoardData))]
        public void Solve_NoGuessing_Ok(int[,] cells)
        {
            var game = new Game(cells);
            var solvedGame = game.Solve();

            Assert.True(solvedGame != null);
        }

        [Theory]
        [Trait("Category", "Solve game")]
        [ClassData(typeof(IntermediateSudokuBoardData))]
        [ClassData(typeof(HardSudokuBoardData))]
        [ClassData(typeof(VeryHardSudokuBoardData))]
        public void Solve_WithGuessing_Ok(int[,] cells)
        {
            var game = new Game(cells);
            var solvedGame = game.Solve();

            Assert.True(solvedGame != null);
        }

        [Theory]
        [Trait("Category", "Algorithm")]
        [ClassData(typeof(IntermediateSudokuBoardData))]
        public void Get_Cell_With_Least_Solutions_Returns_2(int[,] cells)
        {
            var game = new Game(cells);
            var cell = game.FindCellWithLeastSolutions().Value;

            Assert.Equal(2, cell.Solutions.Count());
        }

        [Theory]
        [Trait("Category", "Algorithm")]
        [ClassData(typeof(EasySudokuBoardData))]
        public void Get_Cell_With_Least_Solutions_Returns_1(int[,] cells)
        {
            var game = new Game(cells);
            var cell = game.FindCellWithLeastSolutions().Value;

            Assert.Single(cell.Solutions);
        }

        [Theory]
        [Trait("Category", "Cloning")]
        [ClassData(typeof(EasySudokuBoardData))]
        public void Clone_Ok(int[,] cells)
        {
            var game = new Game(cells);
            var clone = game.Clone();
            game.Board = null;

            Assert.NotNull(clone.Board);
        }
    }
}
