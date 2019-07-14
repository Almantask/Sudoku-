using BenchmarkDotNet.Running;

namespace Sudoku.Benchmarks
{
    public class Benchmarks
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SudokuBenchmarks>();
        }
    }
}
