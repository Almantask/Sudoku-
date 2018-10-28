using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Sudoku.Data;
using Sudoku.Rules;

namespace ConsoleApp1
{
    public class SudokuBenchmarks
    {
        public SudokuBenchmarks()
        {
            
        }

        [Benchmark]
        public void EasySolution()
        {
            var _game = new Game(Sudokus.EasySudoku);
            _game.Solve();
        }
        
    }
}
