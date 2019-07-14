using System;
using Sudoku.Core.Rules;
using Sudoku.View.Data;

namespace SudokuView
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(Sudokus.EasySudoku);
            var gameView = new GameView(game);
            gameView.Refresh();
            Console.WriteLine("After solving");
            game.Solve();
            gameView.Refresh();
        }
    }
}
