using aoc_2022.Utils;
using System.Text;

namespace aoc_2022.Days
{
    public class Day9 : IDay
    {
        public string Part1(string filePath)
        {
            return Run(filePath, 2);
        }


        public string Part2(string filePath)
        {
            return Run(filePath, 10);
        }

        private string Run(string filePath, int ropeLength)
        {
            int[] xs = Enumerable.Repeat(0, ropeLength).ToArray();
            int[] ys = Enumerable.Repeat(0, ropeLength).ToArray();

            HashSet<Location> seen = new HashSet<Location>() { new Location(0, 0) };

            foreach (string instruction in File.ReadLines(filePath))
            {
                var split = instruction.Split(' ');
                int steps = int.Parse(split[1]);
                switch (split[0])
                {
                    case "U": MoveSteps(xs, ys, 0, -1, steps, seen); break;
                    case "D": MoveSteps(xs, ys, 0, 1, steps, seen); break;
                    case "L": MoveSteps(xs, ys, -1, 0, steps, seen); break;
                    case "R": MoveSteps(xs, ys, 1, 0, steps, seen); break;
                }
            }

            return seen.Count.ToString();
        }

        private void PrintGrid(int[] xs, int[] ys, int size)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = -size / 2; y < size / 2; y++)
            {
                string line = "";
                for (int x = -size / 2; x < size / 2; x++)
                {
                    bool hit = false;
                    for (int i = 0; i < xs.Length; i++)
                    {
                        if (xs[i] == x && ys[i] == y)
                        {
                            line += i == 0 ? "H" : i.ToString();
                            hit = true; break;
                        }
                    }

                    if (!hit)
                    {
                        line += ".";
                    }
                }
                sb.AppendLine(line);
            }

            sb.AppendLine();
            Console.Write(sb.ToString());
        }

        private void MoveSteps(int[] xs, int[] ys, int dx, int dy, int steps, HashSet<Location> seen)
        {
            for (int i = 0; i < steps; i++)
            {
                int[] prevXs = xs.ToArray();
                int[] prevYs = ys.ToArray();

                xs[0] += dx;
                ys[0] += dy;

                for (int j = 1; j < xs.Length; j++)
                {
                    int xDist = Math.Abs(xs[j - 1] - xs[j]);
                    int yDist = Math.Abs(ys[j - 1] - ys[j]);

                    int xDistPrev = Math.Abs(prevXs[j - 1] - prevXs[j]);
                    int yDistPrev = Math.Abs(prevYs[j - 1] - prevYs[j]);

                    bool gotPulled = xDist > 1 || yDist > 1;

                    if (gotPulled)
                    {
                        if (xDistPrev + yDistPrev == 1)
                        {
                            xs[j] = xs[j - 1] - (prevXs[j - 1] - prevXs[j]);
                            ys[j] = ys[j - 1] - (prevYs[j - 1] - prevYs[j]);
                        }
                        else if (xDist + yDist > 2)
                        {
                            xs[j] = prevXs[j - 1];
                            ys[j] = prevYs[j - 1];
                        }
                        else if (yDist == 2 && xDist == 0)
                        {
                            int distY = ys[j - 1] - ys[j];
                            ys[j] = ys[j] + (distY > 0 ? distY - 1 : distY + 1);
                        }
                        else if (xDist == 2 && yDist == 0)
                        {
                            int distX = xs[j - 1] - xs[j];
                            xs[j] = xs[j] + (distX > 0 ? distX - 1 : distX + 1);
                        }
                    }

                    if (j == xs.Length - 1)
                    {
                        seen.Add(new Location(xs[j], ys[j]));
                    }
                }
            }
        }

    }
}
