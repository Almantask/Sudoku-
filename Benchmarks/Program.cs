using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    public class Benchmarks
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SudokuBenchmarks>();
        }
    }
}
