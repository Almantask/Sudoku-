using System;
using System.Text;
using Sudoku.Core;
using Sudoku.Core.Rules;

namespace SudokuView
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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
            while(!isNumber || Generator.IsValidHiddenCount(number))
            {

                Console.Write($"'{input}' is not a valid hidden amount. Should be a number between {Generator.MinHiddenCount} and {Generator.MaxHiddenCount}. Try again: ");
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out number);
            }

            return number;
        }

        private static void SolveGeneratedSudoku(int hidden)
        {
            var cells = Generator.Generate(hidden);

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
