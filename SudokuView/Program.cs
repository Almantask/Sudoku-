using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Rules;
using SudokuView.Data;

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
