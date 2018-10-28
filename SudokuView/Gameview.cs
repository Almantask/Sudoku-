using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Rules;

namespace SudokuView
{
    class GameView
    {
        private Game _game;
        public GameView(Game game)
        {
            _game = game;
        }

        public void Refresh()
        {
            var cells = _game.Board.Cells;
            DrawHorizontalBorder();
            for (int x = 0; x < 9; x++)
            {
                Console.Write("|");
                for (int y = 0; y < 9; y++)
                {
                    var value = cells[x, y];
                    DrawCell(value);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            DrawHorizontalBorder();
        }

        private void DrawCell(int value)
        {
            if (value == 0)
                Console.Write("?");
            else
                Console.Write(value);
        }

        private void DrawHorizontalBorder()
        {
            Console.WriteLine("-----------");
        }
    }
}
