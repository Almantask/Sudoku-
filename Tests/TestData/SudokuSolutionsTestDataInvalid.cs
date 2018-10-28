using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsTestDataInvalid : SudokuSolutionsTestData
    {

        public SudokuSolutionsTestDataInvalid()
        {
            _data = new List<object[]>
            {
                new object[] { SudSolVal(1,2,3), SudSolVal(4,5,6), SudSolVal(7,8,9)},
                new object[] { SudSolVal(2), SudSolVal(3), SudSolVal(4)},
                new object[] { SudSolVal(), SudSolVal(), SudSolVal()},
                new object[] { SudSolVal(), SudSolVal(1), SudSolVal(1)},
                new object[] { SudSolVal(), SudSolVal(), SudSolVal(2) }
            };
        }
    }
}