using aoc_2022.Utils;
using System;

namespace aoc_2022.Days
{
    public class Day12 : IDay
    {
        public string Part1(string filePath)
        {
            (int[,] grid, Location start, Location end) = ParseGrid(filePath);
            return Run(grid, start, end).ToString();
        }

        public string Part2(string filePath)
        {
            (int[,] grid, Location _, Location end) = ParseGrid(filePath);
            return Run(grid, end, null).ToString();
        }

        private int Run(int[,] grid, Location start, Location? end)
        {
            HashSet<Location> seen = new HashSet<Location>();
            List<Location> candidates = new List<Location>() { start };
            bool part1 = end != null;

            int i = 0;
            while (candidates.Any())
            {
                List<Location> nextCandidates = new List<Location>();

                foreach (Location current in candidates)
                {
                    if (seen.Contains(current)) continue;
                    seen.Add(current);

                    if (part1 && current == end || !part1 && grid[current.X, current.Y] == 1)
                    {
                        return i;
                    }

                    nextCandidates.AddRange(new[] {
                        new Location(current.X + 1, current.Y),
                        new Location(current.X - 1, current.Y),
                        new Location(current.X, current.Y + 1),
                        new Location(current.X, current.Y - 1)
                    }.Where(next => IsValidDirection(grid, current, next, part1)));
                }
                candidates = nextCandidates;
                i++;
            }

            return 0;
        }

        private bool IsValidDirection(int[,] grid, Location current, Location next, bool part1)
        {
            if (next.X < 0 || next.X >= grid.GetLength(0) || next.Y < 0 || next.Y >= grid.GetLength(1))
            {
                return false;
            }

            return part1
                ? grid[next.X, next.Y] - grid[current.X, current.Y] <= 1
                : grid[current.X, current.Y] - grid[next.X, next.Y] <= 1;
        }

        private (int[,] grid, Location start, Location end) ParseGrid(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Location start = new Location(0, 0);
            Location end = new Location(0, 0);

            int[,] grid = new int[lines[0].Length, lines.Length];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    if (lines[y][x] == 'S')
                    {
                        grid[x, y] = 0;
                        start = new Location(x, y);
                    }
                    else if (lines[y][x] == 'E')
                    {
                        grid[x, y] = 26;
                        end = new Location(x, y);
                    }
                    else
                    {
                        grid[x, y] = (lines[y][x] - 'a') + 1;
                    }
                }
            }

            return (grid, start, end);
        }
    }
}
