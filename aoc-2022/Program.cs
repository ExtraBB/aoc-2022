using aoc_2022.Days;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DaysBenchmark>();
        }
    }
}
