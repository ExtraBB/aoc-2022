using System.Text;

namespace aoc_2022.Days
{
    public class Day10 : IDay
    {
        public string Part1(string filePath)
        {
            int result = 0;

            Run(filePath, (x, cycle) =>
            {
                if ((cycle + 20) % 40 == 0)
                {
                    result += x * cycle;
                }
            });

            return result.ToString();
        }

        public string Part2(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            Run(filePath, (x, cycle) =>
            {
                bool spriteVisible = new int[] { (cycle - 1) % 40 - 1, (cycle - 1) % 40, (cycle - 1) % 40 + 1 }
                    .Where(c => c >= 0 && c < 40)
                    .Any(c => c == x);

                sb.Append(spriteVisible ? "#" : ".");
                if (cycle % 40 == 0)
                {
                    sb.Append(Environment.NewLine);
                }
            });

            return sb.ToString();
        }

        private void Run(string filePath, Action<int, int> action)
        {
            int x = 1;
            int cycle = 1;

            foreach (string line in File.ReadLines(filePath))
            {
                action(x, cycle);

                if (line != "noop")
                {
                    cycle++;
                    action(x, cycle);
                    x += int.Parse(line.Substring("addx ".Length));
                }

                cycle++;
            }
        }
    }
}
