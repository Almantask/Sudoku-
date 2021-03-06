﻿using Sudoku.Core.Rules;
using System;

namespace SudokuView
{
    class GameView
    {
        private readonly Game _game;
        public GameView(Game game)
        {
            _game = game;
        }

        public void Refresh()
        {
            var cells = _game.Board.CellsSolution;
            DrawHorizontalBorder(VerticalPosition.Bot);
            for (var x = 0; x < 9; x++)
            {
                Console.Write("|");
                for (var y = 0; y < 9; y++)
                {
                    var value = cells[x, y];
                    DrawCell(value);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            DrawHorizontalBorder(VerticalPosition.Top);
        }

        private void DrawCell(int value) => Console.Write(value == 0 ? "?" : value.ToString());

        private void DrawHorizontalBorder(VerticalPosition position) 
            => Console.WriteLine(position == VerticalPosition.Bot ? "___________" : "‾‾‾‾‾‾‾‾‾‾‾");

    }
}
