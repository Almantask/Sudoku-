using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsTestDataValid : SudokuSolutionsTestData
    {
        public SudokuSolutionsTestDataValid()
        {
            _data = new List<object[]>
            {
                new object[] {SudSolVal(1), SudSolVal(1), SudSolVal(1)},
                new object[] {SudSolVal(1, 2, 3), SudSolVal(3, 4, 5), SudSolVal(3, 6, 7)},
            };
        }
    }
}