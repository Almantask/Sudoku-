using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Sudoku.SudokuElements;

namespace Tests.TestData
{
    public class SudokuSolutionsTestData : IEnumerable<object[]>
    {
        protected List<object[]> _data;

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected static SudokuElementSolution SudSolVal(params int[] possibilities)
        {
            return new SudokuElementSolution(possibilities);
        }
    }
}
