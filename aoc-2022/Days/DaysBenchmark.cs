﻿using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022.Days
{
    public class DaysBenchmark
    {
        [Benchmark]
        public void Day1Part1()
        {
            Day1.Part1("./Files/1-actual.txt");
        }

        [Benchmark]
        public void Day1Part2()
        {
            Day1.Part2("./Files/1-actual.txt");
        }
    }
}
