using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Core.Extensions;
using Xunit;

namespace Sudoku.Tests
{
    public class ShuffleTests
    {
        [Fact]
        [Trait("Category", "Extensions")]
        public void Shuffle_Ok()
        {
            var numbers = new List<int>() { 1, 5, 6, 7 };
            var shuffled = numbers.Shuffle();

            Assert.Equal(numbers.Count, shuffled.Count);
        }
    }
}
