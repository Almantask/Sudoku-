using System;
using Sudoku.Core;
using Sudoku.Core.Rules;
using Sudoku.View.Data;

namespace SudokuView
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var hidden = PromptForHiddenCellsAmount();
                SolveGeneratedSudoku(hidden);
            }
            while (IsPromptForRetry());
        }

        private static int PromptForHiddenCellsAmount()
        {

            Console.Write($"Please insert amount of empty cells in {Game.SudokuSize}x{Game.SudokuSize} matrix: ");

            var input = Console.ReadLine();
            var isNumber = int.TryParse(input, out var number);
            while(!isNumber)
            {
                Console.Write($"'{input}' is not a number! Try again: ");
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out number);
            }

            return number;
        }

        private static void SolveGeneratedSudoku(int hidden)
        {
            var generator = new Generator();
            var cells = generator.Generate(hidden);

            var game = new Game(cells);
            var gameView = new GameView(game);
            gameView.Refresh();

            Console.WriteLine("After solving");
            var solution = game.Solve();
            gameView = new GameView(solution);
            gameView.Refresh();
        }

        private static bool IsPromptForRetry()
        {
            Console.Write("Would you like to retry? ");
            var isYes = Console.ReadKey().KeyChar.ToString().ToLower() == "y";
            Console.WriteLine();

            return isYes;
        }
    }
}
