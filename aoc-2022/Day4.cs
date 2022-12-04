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
            return File.ReadAllLines(filePath)
                .Select(line => regex.Match(line).Groups.Values.Skip(1).Select(g => int.Parse(g.Value)).ToArray())
                .Where(IsFullyContained)
                .Count()
                .ToString();
        }

        private bool IsFullyContained(int[] ranges)
        {
            bool aContainsB = ranges[0] >= ranges[2] && ranges[1] <= ranges[3];
            bool bContainsA = ranges[2] >= ranges[0] && ranges[3] <= ranges[1];
            return aContainsB || bContainsA;

        }

        public string Part2(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
