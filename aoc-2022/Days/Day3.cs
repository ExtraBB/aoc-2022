namespace aoc_2022.Days
{
    public class Day3 : IDay
    {
        public string Part1(string filePath, bool debug = false)
        {
            return File.ReadAllLines(filePath)
                .Select(line => new[] { line.Take(line.Length / 2), line.Skip(line.Length / 2) })
                .SelectMany(chunks => chunks[0].Intersect(chunks[1]))
                .Select(GetValueForChar)
                .Sum()
                .ToString();
        }

        public string Part2(string filePath, bool debug = false)
        {
            return File.ReadAllLines(filePath)
                .Chunk(3)
                .SelectMany(chunks => chunks[0].Intersect(chunks[1]).Intersect(chunks[2]))
                .Select(GetValueForChar)
                .Sum()
                .ToString();
        }

        private int GetValueForChar(char c)
        {
            if (char.IsLower(c))
            {
                return c - 'a' + 1;
            }
            return c - 'A' + 27;
        }
    }
}
