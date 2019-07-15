using BenchmarkDotNet.Attributes;
using Sudoku.Benchmarks.TestData;
using Sudoku.Core.Rules;

namespace Sudoku.Benchmarks
{
    public class SudokuBenchmarks
    {
        [Benchmark]
        public void BenchmarkEasySolution()
        {
            var _game = new Game(EasySudokuBoardData.Cells);
            _game.Solve();
        }
        
    }
}
