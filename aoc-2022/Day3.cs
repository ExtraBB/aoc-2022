using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
    public class Day3 : IDay
    {
        public string Part1(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Select(FindError)
                .Sum()
                .ToString();
        }

        public string Part2(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Chunk(3)
                .Select(FindBadge)
                .Sum()
                .ToString();
        }

        private int FindError(string line)
        {
            HashSet<char> chars = new HashSet<char>();

            for (int i = 0; i < line.Length / 2; i++)
            {
                chars.Add(line[i]);
            }

            for (int i = line.Length / 2; i < line.Length; i++)
            {
                if (chars.Contains(line[i]))
                {
                    return GetValueForChar(line[i]);
                }
            }

            throw new ArgumentException(nameof(line));
        }

        private int FindBadge(IEnumerable<string> lines)
        {
            Dictionary<char, int> seen = new Dictionary<char, int>();

            foreach (string line in lines)
            {
                foreach (char c in line.Distinct())
                {
                    if (seen.ContainsKey(c))
                    {
                        if (seen[c] == 2)
                        {
                            return GetValueForChar(c);
                        }
                        else
                        {
                            seen[c] = seen[c] + 1;
                        }
                    }
                    else
                    {
                        seen[c] = 1;
                    }
                }
            }

            throw new ArgumentException(nameof(lines));
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
