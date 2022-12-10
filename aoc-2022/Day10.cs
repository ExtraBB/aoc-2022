using System.Text;

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
            int x = 1;
            int cycle = 1;

            StringBuilder sb = new StringBuilder();
            string pixels = "";

            foreach (string line in File.ReadLines(filePath))
            {
                pixels += SpriteVisible(x, cycle) ? "#" : ".";
                if (cycle % 40 == 0)
                {
                    sb.AppendLine(pixels);
                    pixels = "";
                }

                if (line != "noop")
                {
                    int toAdd = int.Parse(line.Substring("addx ".Length));

                    cycle++;

                    pixels += SpriteVisible(x, cycle) ? "#" : ".";
                    if (cycle % 40 == 0)
                    {
                        sb.AppendLine(pixels);
                        pixels = "";
                    }

                    x += toAdd;
                }

                cycle++;
            }

            return sb.ToString();
        }

        private bool SpriteVisible(int x, int cycle)
        {
            return new int[] { ((cycle - 1) % 40) - 1, (cycle - 1) % 40, ((cycle - 1) % 40) + 1 }
                .Where(c => c >= 0 && c < 40)
                .Any(c => c == x);
        }
    }
}
