using Sudoku.Core.Extensions;
using Sudoku.Core.Rules;
using Sudoku.Core.SudokuElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core.SudokuGenerator
{
    internal class RandomGame: Game
    {
        private protected override void Guess(Game game, CellWithSolutions cellWithLeastSolutions)
        {
            var mixedSolutions = cellWithLeastSolutions.Solutions.ToList().Shuffle();
            foreach (var guess in mixedSolutions)
            {
                var gameSnapshot = game.Clone();
                gameSnapshot.AssignGuess(cellWithLeastSolutions, guess);
                Solve(gameSnapshot);
            }
        }
    }
}
