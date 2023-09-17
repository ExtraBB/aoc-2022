using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022.Days
{
    public interface IDay
    {
        string Part1(string filePath, bool debug = false);
        string Part2(string filePath, bool debug = false);
    }
}
