using System.Collections.Generic;

namespace Tests.TestData
{
    public class SudokuSolutionsPossibilityRemovalValidData:SudokuSolutionsTestData
    {
        public SudokuSolutionsPossibilityRemovalValidData()
        {
            _data = new List<object[]>
            {
                new object[] {SudSolVal(1), SudSolVal(1), SudSolVal(1), 1},
                new object[] {SudSolVal(1, 2, 3), SudSolVal(3, 4, 5), SudSolVal(3, 6, 7), 3}
            };
        }

        
    }

    public class SudokuSolutionsPossibilityRemovalInvalidData : SudokuSolutionsTestData
    {
        public SudokuSolutionsPossibilityRemovalInvalidData()
        {
            _data = new List<object[]>
            {
                new object[] {SudSolVal(), SudSolVal(), SudSolVal(), 2},
                new object[] {SudSolVal(), SudSolVal(1), SudSolVal(1), 1},
                new object[] {SudSolVal(2), SudSolVal(3), SudSolVal(4), 3},
                new object[] {SudSolVal(1, 2, 3), SudSolVal(4, 5, 6), SudSolVal(7, 8, 9), 0},
            };
        }


    }
}