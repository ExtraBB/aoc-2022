using BenchmarkDotNet.Attributes;

namespace aoc_2022_test.Benchmarks
{
    public class DaysBenchmark
    {
        [BenchmarkDotNet.Attributes.Arguments("./Files/1-actual.txt")]
        public void Day1Part1()
        {
            new Day1().Part1("./Files/1-actual.txt");
        }

        [Benchmark]
        public void Day1Part2()
        {
            new Day1().Part2("./Files/1-actual.txt");
        }

        [Benchmark]
        public void Day2Part1()
        {
            new Day2().Part1("./Files/2-actual.txt");
        }

        [Benchmark]
        public void Day2Part2()
        {
            new Day2().Part2("./Files/2-actual.txt");
        }

        [Benchmark]
        public void Day3Part1()
        {
            new Day3().Part1("./Files/3-actual.txt");
        }

        [Benchmark]
        public void Day3Part2()
        {
            new Day3().Part2("./Files/3-actual.txt");
        }

        [Benchmark]
        public void Day4Part1()
        {
            new Day4().Part1("./Files/4-actual.txt");
        }

        [Benchmark]
        public void Day4Part2()
        {
            new Day4().Part2("./Files/4-actual.txt");
        }

        [Benchmark]
        public void Day5Part1()
        {
            new Day5().Part1("./Files/5-actual.txt");
        }

        [Benchmark]
        public void Day5Part2()
        {
            new Day5().Part2("./Files/5-actual.txt");
        }

        [Benchmark]
        public void Day6Part1()
        {
            new Day6().Part1("./Files/6-actual.txt");
        }

        [Benchmark]
        public void Day6Part2()
        {
            new Day6().Part2("./Files/6-actual.txt");
        }

        [Benchmark]
        public void Day7Part1()
        {
            new Day7().Part1("./Files/7-actual.txt");
        }

        [Benchmark]
        public void Day7Part2()
        {
            new Day7().Part2("./Files/7-actual.txt");
        }

        [Benchmark]
        public void Day8Part1()
        {
            new Day8().Part1("./Files/8-actual.txt");
        }

        [Benchmark]
        public void Day8Part2()
        {
            new Day8().Part2("./Files/8-actual.txt");
        }
    }
}
