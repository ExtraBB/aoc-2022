using System.Text.RegularExpressions;

namespace aoc_2022
{
    public class Day4 : IDay
    {
        Regex regex = new Regex(@"(\d+)\-(\d+)\,(\d+)\-(\d+)");

        public string Part1(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Select(line => Helpers.ParseGroupsFromStringAndConvert(regex, line, int.Parse))
                .Count(IsFullyContained)
                .ToString();
        }

        public string Part2(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Select(line => Helpers.ParseGroupsFromStringAndConvert(regex, line, int.Parse))
                .Count(Overlap)
                .ToString();
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
