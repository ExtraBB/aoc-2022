using aoc_2022;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022_test.Benchmarks
{
    public class DaysBenchmark
    {
        [Benchmark]
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
    }
}
