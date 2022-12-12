using aoc_2022.Utils;
using System;

namespace aoc_2022.Days
{
    public class Day12 : IDay
    {
        public string Part1(string filePath)
        {
            (int[,] grid, Location start, Location end) = ParseGrid(filePath);
            var seen = Run(grid, start, end, true);
            return seen[end].ToString();
        }

        public string Part2(string filePath)
        {
            (int[,] grid, Location start, Location end) = ParseGrid(filePath);
            var seen = Run(grid, end, null, false);
            return seen.Where(kvp => grid[kvp.Key.X, kvp.Key.Y] == 1).Max(kvp => kvp.Value).ToString();
        }

        private Dictionary<Location, int> Run(int[,] grid, Location start, Location end, bool part1)
        {
            Dictionary<Location, int> seen = new Dictionary<Location, int>();

            Queue<Location> next = new Queue<Location>();
            next.Enqueue(start);

            for (int i = 0; i < int.MaxValue; i++)
            {
                Queue<Location> nextIteration = new Queue<Location>();
                while (next.Count > 0)
                {
                    Location n = next.Dequeue();
                    if (seen.ContainsKey(n))
                    {
                        continue;
                    } 
                    else
                    {
                        seen[n] = i;
                    }

                    if (n == end || (!part1 && grid[n.X, n.Y] == 1))
                    {
                        return seen;
                    }

                    var candidates = new[]
                    {
                        CheckDirection(grid, n, 1, 0, part1),
                        CheckDirection(grid, n, -1, 0, part1),
                        CheckDirection(grid, n, 0, -1, part1),
                        CheckDirection(grid, n, 0, 1, part1)
                    }.Where(l => l != null && !seen.ContainsKey(l));

                    foreach(var c in candidates)
                    {
                        nextIteration.Enqueue(c);
                    }
                }
                next = nextIteration;
            }

            return seen;
        }

        private Location? CheckDirection(int[,] grid, Location current, int dx, int dy, bool part1)
        {
            Location next = new Location(current.X + dx, current.Y + dy);
            if (next.X >= 0 && next.X < grid.GetLength(0) && next.Y >= 0 && next.Y < grid.GetLength(1))
            {
                if (part1)
                {
                    return grid[next.X, next.Y] - grid[current.X, current.Y] <= 1 ? next : null;
                }
                else
                {
                    return grid[current.X, current.Y] - grid[next.X, next.Y] <= 1 ? next : null;
                }
            }

            return null;
        }

        private (int[,] grid, Location start, Location end) ParseGrid(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Location start = new Location(0, 0);
            Location end = new Location(0, 0);

            int[,] grid = new int[lines[0].Length, lines.Length];

            for(int y = 0; y < lines.Length; y++)
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
