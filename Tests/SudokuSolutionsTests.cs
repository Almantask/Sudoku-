using System;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Rules;
using Sudoku.SudokuElements;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class SudokuSolutionsTests
    {
        [Theory]
        [ClassData(typeof(SudokuSolutionsTestDataValid))]
        public void TestGettingValidSolution(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col)
        {
            var elements = new[] {square, row, col};
            var result = SudokuElementSolution.GetUniqueCellSolution(elements);
            Assert.NotEqual(SudokuElementSolution.INVALID_VALUE, result);
        }

        [Theory]
        [ClassData(typeof(SudokuSolutionsTestDataInvalid))]
        public void TestGettingInvalidSolution(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col)
        {
            var elements = new[] { square, row, col };
            var result = SudokuElementSolution.GetUniqueCellSolution(elements);
            Assert.Equal(SudokuElementSolution.INVALID_VALUE, result);
        }

        [Theory]
        [ClassData(typeof(SudokuSolutionsTestDataInvalid))]
        [ClassData(typeof(SudokuSolutionsTestDataValid))]
        public void TestGettingValidValues(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col)
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
        [ClassData(typeof(SudokuSolutionsPossibilityRemovalValidData))]
        public void TestRemoveValidPossibility(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col, int possibility)
        {
            var elements = new[] { square, row, col };
            SudokuElementSolution.RemovePossibility(elements, possibility);
            foreach (var element in elements)
            {
                Assert.DoesNotContain(possibility, element.GetPossibilities());
            }
        }

        [Theory]
        [ClassData(typeof(SudokuSolutionsPossibilityRemovalInvalidData))]
        public void TestRemoveInvalidPossibility(SudokuElementSolution square, SudokuElementSolution row, SudokuElementSolution col, int possibility)
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
        public void TestGetPossibilitiesEmpty()
        {
            var sudokuElement = new SudokuElementSolution(new int[] {});
            Assert.Equal(0, sudokuElement.GetPossibilities().FirstOrDefault());
        }

        [Fact]
        public void TestGetPossibilitiesFilled()
        {
            var sudokuElement = new SudokuElementSolution(1, 2, 3);
            Assert.Equal(3, sudokuElement.GetPossibilities().Count());
        }
    }
}
