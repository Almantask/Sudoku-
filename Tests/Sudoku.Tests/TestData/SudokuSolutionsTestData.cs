using System.Collections;
using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsTestData : IEnumerable<object[]>
    {
        protected List<object[]> _data;

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
