using System.Linq;
using Sudoku.Core.SudokuElements;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class SudokuSolutionsTests
    {
        [Theory]
        [Trait("Category", "Board elements")]
        [ClassData(typeof(SudokuSolutionsTestDataInvalid))]
        [ClassData(typeof(SudokuSolutionsTestDataValid))]
        public void Get_Valid_Value_Ok(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col)
        {
            var elements = new[] { square, row, col };
            var result = SudokuElementSolution.GetValidValues(elements);
            foreach (var val in result)
            {
                foreach (var element in elements)
                {
                    Assert.Contains(val, element.GetPossibilities());
                }
            }
        }

        [Theory]
        [Trait("Category", "Board elements")]
        [ClassData(typeof(SudokuSolutionsPossibilityRemovalValidData))]
        public void Remove_Valid_Possibility_Ok(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col, int possibility)
        {
            var elements = new[] { square, row, col };
            SudokuElementSolution.RemovePossibility(elements, possibility);
            foreach (var element in elements)
            {
                Assert.DoesNotContain(possibility, element.GetPossibilities());
            }
        }

        [Theory]
        [Trait("Category", "Board elements")]
        [ClassData(typeof(SudokuSolutionsPossibilityRemovalInvalidData))]
        public void Remove_Invalid_Possibility_Fail(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col, int possibility)
        {
            var elements = new[] { square, row, col };
            var didFail = false;
            try
            {
                SudokuElementSolution.RemovePossibility(elements, possibility);
            }
            catch
            {
                didFail = true;
            }
            Assert.True(didFail);
        }

        [Fact]
        [Trait("Category", "Board elements")]
        public void Get_Possibilities_Empty_Ok()
        {
            var sudokuElement = new SudokuElementSolution(new int[] { });
            Assert.Equal(0, sudokuElement.GetPossibilities().FirstOrDefault());
        }

        [Fact]
        [Trait("Category", "Board elements")]
        public void Get_Possibilities_Filled_Ok()
        {
            var sudokuElement = new SudokuElementSolution(1, 2, 3);
            Assert.Equal(3, sudokuElement.GetPossibilities().Count());
        }

        [Fact]
        [Trait("Category", "Cloning")]
        public void Clone_Ok()
        {
            const int solutionForOriginal = 1;
            var sudokuElement = new SudokuElementSolution(solutionForOriginal);
            var clone = sudokuElement.Clone();
            sudokuElement.RemovePossibility(solutionForOriginal);
            Assert.Contains(solutionForOriginal, clone.GetPossibilities());
        }
    }
}
