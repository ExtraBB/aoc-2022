using BenchmarkDotNet.Attributes;

namespace aoc_2022_test.Benchmarks
{
    public class DaysBenchmark
    {
        [BenchmarkDotNet.Attributes.Arguments("./Inputs/Actual/1.txt")]
        public void Day1Part1()
        {
            new Day1().Part1("./Inputs/Actual/1.txt");
        }

        [Benchmark]
        public void Day1Part2()
        {
            new Day1().Part2("./Inputs/Actual/1.txt");
        }

        [Benchmark]
        public void Day2Part1()
        {
            new Day2().Part1("./Inputs/Actual/2.txt");
        }

        [Benchmark]
        public void Day2Part2()
        {
            new Day2().Part2("./Inputs/Actual/2.txt");
        }

        [Benchmark]
        public void Day3Part1()
        {
            new Day3().Part1("./Inputs/Actual/3.txt");
        }

        [Benchmark]
        public void Day3Part2()
        {
            new Day3().Part2("./Inputs/Actual/3.txt");
        }

        [Benchmark]
        public void Day4Part1()
        {
            new Day4().Part1("./Inputs/Actual/4.txt");
        }

        [Benchmark]
        public void Day4Part2()
        {
            new Day4().Part2("./Inputs/Actual/4.txt");
        }

        [Benchmark]
        public void Day5Part1()
        {
            new Day5().Part1("./Inputs/Actual/5.txt");
        }

        [Benchmark]
        public void Day5Part2()
        {
            new Day5().Part2("./Inputs/Actual/5.txt");
        }

        [Benchmark]
        public void Day6Part1()
        {
            new Day6().Part1("./Inputs/Actual/6.txt");
        }

        [Benchmark]
        public void Day6Part2()
        {
            new Day6().Part2("./Inputs/Actual/6.txt");
        }

        [Benchmark]
        public void Day7Part1()
        {
            new Day7().Part1("./Inputs/Actual/7.txt");
        }

        [Benchmark]
        public void Day7Part2()
        {
            new Day7().Part2("./Inputs/Actual/7.txt");
        }

        [Benchmark]
        public void Day8Part1()
        {
            new Day8().Part1("./Inputs/Actual/8.txt");
        }

        [Benchmark]
        public void Day8Part2()
        {
            new Day8().Part2("./Inputs/Actual/8.txt");
        }

        [Benchmark]
        public void Day9Part1()
        {
            new Day9().Part1("./Inputs/Actual/9.txt");
        }

        [Benchmark]
        public void Day9Part2()
        {
            new Day9().Part2("./Inputs/Actual/9.txt");
        }

        [Benchmark]
        public void Day10Part1()
        {
            new Day10().Part1("./Inputs/Actual/10.txt");
        }

        [Benchmark]
        public void Day10Part2()
        {
            new Day10().Part2("./Inputs/Actual/10.txt");
        }
    }
}
