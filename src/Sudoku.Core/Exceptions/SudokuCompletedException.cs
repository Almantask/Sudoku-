using Sudoku.Core.Rules;
using System;

namespace Sudoku.Core.Exceptions
{
    /// <summary>
    /// This kind of exception is exceptionally bad :).
    /// Used just for returning from recursion
    /// </summary>
    internal class SudokuCompletedException: Exception
    {
        public Game Game { get; }
        public SudokuCompletedException(Game game)
        {
            Game = game;
        }
    }
}
