using Sudoku.Core;
using Sudoku.Core.Exceptions;
using Sudoku.Core.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sudoku.Tests
{
    public class GeneratorTests
    {
        private Generator _generator = new Generator();

        [Theory]
        [Trait("Category", "Generating")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(35)]
        public void Generate_Valid(int hidden)
        {
            var cells = _generator.Generate(hidden);

            var game = new Game(cells);
            var solution = game.Solve();

            Assert.NotNull(solution);
        }

        //[Theory]
        //[Trait("Category", "Generating")]
        //[InlineData(40)]
        //[InlineData(45)]
        //[InlineData(50)]
        //[InlineData(55)]
        //[InlineData(60)]
        //[InlineData(65)]
        //[InlineData(70)]
        //[InlineData(75)]
        //[InlineData(80)]
        //public void Generate_Long_Solving_Valid(int hidden)
        //{
        //    var cells = _generator.Generate(hidden);

        //    var game = new Game(cells);
        //    var solution = game.Solve();

        //    Assert.NotNull(solution);
        //}

        [Theory]
        [Trait("Category", "Generating")]
        [InlineData(81)]
        [InlineData(0)]
        public void Generate_Invalid(int hidden)
        {
            var failed = false;

            try
            {
                _generator.Generate(hidden);
            }
            catch (InvalidHiddenCellsCountException)
            {
                failed = true;
            }

            Assert.True(failed);
        }
    }
}
