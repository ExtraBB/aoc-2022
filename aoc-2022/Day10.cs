namespace aoc_2022
{
    internal class Day10 : IDay
    {
        public string Part1(string filePath)
        {
            var cyclesToCount = new HashSet<int>() { 20, 60, 100, 140, 180, 220 };
            int x = 1;
            int cycle = 1;
            int result = 0;

            foreach (string line in File.ReadLines(filePath))
            {
                if (cyclesToCount.Contains(cycle))
                {
                    result += cycle * x;
                }

                if (line != "noop")
                {
                    int toAdd = int.Parse(line.Substring("addx ".Length));

                    cycle++;
                    if (cyclesToCount.Contains(cycle))
                    {
                        result += cycle * x;
                    }

                    x += toAdd;
                }

                cycle++;
            }

            return result.ToString();
        }

        public string Part2(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
