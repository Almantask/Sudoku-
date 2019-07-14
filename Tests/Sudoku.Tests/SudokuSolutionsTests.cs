using System.Linq;
using Sudoku.Core.SudokuElements;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class SudokuSolutionsTests
    {
        [Theory]
        [Trait("Category", "Board elments")]
        [ClassData(typeof(SudokuSolutionsTestDataValid))]
        public void Get_Valid_Solution_Ok(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col)
        {
            var elements = new[] {square, row, col};
            var result = SudokuElementSolution.GetUniqueCellSolution(elements);
            Assert.NotEqual(SudokuElementSolution.InvalidValue, result);
        }

        [Theory]
        [Trait("Category", "Board elments")]
        [ClassData(typeof(SudokuSolutionsTestDataInvalid))]
        public void Get_Invalid_Solution_Ok(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col)
        {
            var elements = new[] { square, row, col };
            var result = SudokuElementSolution.GetUniqueCellSolution(elements);
            Assert.Equal(SudokuElementSolution.InvalidValue, result);
        }

        [Theory]
        [Trait("Category", "Board elments")]
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
        [Trait("Category", "Board elments")]
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
        [Trait("Category", "Board elments")]
        public void Get_Possibilities_Empty_Ok()
        {
            var sudokuElement = new SudokuElementSolution(new int[] {});
            Assert.Equal(0, sudokuElement.GetPossibilities().FirstOrDefault());
        }

        [Fact]
        [Trait("Category", "Board elments")]
        public void Get_Possibilities_Filled_Ok()
        {
            var sudokuElement = new SudokuElementSolution(1, 2, 3);
            Assert.Equal(3, sudokuElement.GetPossibilities().Count());
        }
    }
}
