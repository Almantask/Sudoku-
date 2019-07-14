using Sudoku.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.Exceptions
{
    /// <summary>
    /// This kind of exception is exceptionally bad :).
    /// Used just for returning from recursion
    /// </summary>
    public class SudokuCompletedException: Exception
    {
        public Game Game { get; }
        public SudokuCompletedException(Game game)
        {
            Game = game;
        }
    }
}
