using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2022
{
    public class Day4 : IDay
    {
        Regex regex = new Regex(@"(\d+)\-(\d+)\,(\d+)\-(\d+)");

        public string Part1(string filePath)
        {
            return File.ReadAllLines(filePath).Select(ParseRanges).Where(IsFullyContained).Count().ToString();
        }

        public string Part2(string filePath)
        {
            return File.ReadAllLines(filePath).Select(ParseRanges).Where(Overlap).Count().ToString();
        }

        private int[] ParseRanges(string line)
        {
            return regex.Match(line).Groups.Values.Skip(1).Select(g => int.Parse(g.Value)).ToArray();
        }

        private bool IsFullyContained(int[] ranges)
        {
            int overlap = GetOverlap(ranges);
            return overlap == (ranges[1] - ranges[0] + 1) || overlap == (ranges[3] - ranges[2] + 1);
        }

        private bool Overlap(int[] ranges)
        {
            return GetOverlap(ranges) > 0;
        }

        private int GetOverlap(int[] ranges)
        {
            return Math.Max(0, Math.Min(ranges[1], ranges[3]) - Math.Max(ranges[0], ranges[2]) + 1);
        }
    }
}
