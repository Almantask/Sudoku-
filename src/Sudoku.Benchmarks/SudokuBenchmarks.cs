﻿using BenchmarkDotNet.Attributes;
using Sudoku.Core.Data;
using Sudoku.Core.Rules;

namespace Sudoku.Benchmarks
{
    public class SudokuBenchmarks
    {
        [Benchmark]
        public void EasySolution()
        {
            var _game = new Game(Sudokus.EasySudoku);
            _game.Solve();
        }
        
    }
}