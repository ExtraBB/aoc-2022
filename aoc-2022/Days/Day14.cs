namespace aoc_2022.Days;

public class Day14 : IDay
{
    const int ROWS = 200;
    const int COLUMNS = 800;

    public string Part1(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var cave = ParseCave(lines, false);
        return Run(cave).ToString();
    }

    public string Part2(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var cave = ParseCave(lines, true);
        return Run(cave).ToString();
    }

    private char[,] ParseCave(string[] lines, bool hasFloor)
    {
        var parsed = lines.Select(line => line
                        .Split(" -> ")
                        .Select(coord => coord
                            .Split(",")
                            .Select(int.Parse)
                            .ToArray())
                        .ToArray());

        char[,] cave = new char[COLUMNS, ROWS];

        // Fill empty space
        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLUMNS; x++)
            {
                cave[x, y] = '.';
            }
        }

        // Add walls
        foreach (var wall in parsed)
        {
            for (int i = 0; i + 1 < wall.Length; i++)
            {
                if (wall[i][0] == wall[i + 1][0])
                {
                    for (int y = Math.Min(wall[i][1], wall[i + 1][1]); y <= Math.Max(wall[i][1], wall[i + 1][1]); y++)
                    {
                        cave[wall[i][0], y] = '#';
                    }
                }
                else
                {
                    for (int x = Math.Min(wall[i][0], wall[i + 1][0]); x <= Math.Max(wall[i][0], wall[i + 1][0]); x++)
                    {
                        cave[x, wall[i][1]] = '#';
                    }
                }
            }
        }

        // Add floor
        if (hasFloor)
        {
            int maxY = Enumerable.Range(0, ROWS - 1).Reverse().First(y => Enumerable.Range(0, COLUMNS - 1).Any(x => cave[x, y] != '.'));
            for (int x = 0; x < COLUMNS; x++)
            {
                cave[x, maxY + 2] = '#';
            }
        }

        return cave;
    }

    private int Run(char[,] cave)
    {
        int x = 500, y = 0;
        int maxY = Enumerable.Range(0, ROWS - 1).Reverse().First(y => Enumerable.Range(0, COLUMNS - 1).Any(x => cave[x, y] != '.')) + 1;

        int sandDropped = 0;
        while (!TickSand(cave, x, y, maxY))
        {
            sandDropped++;
        }

        return sandDropped;
    }

    private bool TickSand(char[,] cave, int x, int y, int maxY)
    {
        if (y + 1 > maxY || cave[x, y] == 'o')
        {
            return true;
        }

        if (cave[x, y + 1] == '.')
        {
            return TickSand(cave, x, y + 1, maxY);
        }
        else
        {
            if (cave[x - 1, y + 1] == '.')
            {
                return TickSand(cave, x - 1, y + 1, maxY);
            }
            else if (cave[x + 1, y + 1] == '.')
            {
                return TickSand(cave, x + 1, y + 1, maxY);
            }
            else
            {
                cave[x, y] = 'o';
                return false;
            }
        }
    }
}