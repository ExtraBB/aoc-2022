namespace aoc_2022.Days
{
    public class Day2 : IDay
    {
        private Dictionary<string, int> scoresPart1 = new Dictionary<string, int>()
        {
            {"A X", 1 + 3 },
            {"A Y", 2 + 6 },
            {"A Z", 3 + 0 },
            {"B X", 1 + 0 },
            {"B Y", 2 + 3 },
            {"B Z", 3 + 6 },
            {"C X", 1 + 6 },
            {"C Y", 2 + 0 },
            {"C Z", 3 + 3 },
        };

        private Dictionary<string, int> scoresPart2 = new Dictionary<string, int>()
        {
            {"A X", 3 + 0 },
            {"A Y", 1 + 3 },
            {"A Z", 2 + 6 },
            {"B X", 1 + 0 },
            {"B Y", 2 + 3 },
            {"B Z", 3 + 6 },
            {"C X", 2 + 0 },
            {"C Y", 3 + 3 },
            {"C Z", 1 + 6 },
        };

        public string Part1(string filePath)
        {
            return File.ReadAllLines(filePath).Sum(line => scoresPart1[line]).ToString();
        }

        public string Part2(string filePath)
        {
            return File.ReadAllLines(filePath).Sum(line => scoresPart2[line]).ToString();
        }
    }
}
