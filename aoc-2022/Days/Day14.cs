namespace aoc_2022.Days;

public class Day14 : IDay
{
    const int ROWS = 200;
    const int COLUMNS = 600;

    public string Part1(string filePath, bool debug = false)
    {
        var lines = File.ReadAllLines(filePath);
        var cave = ParseCave(lines);
        return Run(cave, debug).ToString();
    }

    public string Part2(string filePath, bool debug = false)
    {
        throw new NotImplementedException();
    }

    private char[,] ParseCave(string[] lines)
    {
        var parsed = lines.Select(line => line
                        .Split(" -> ")
                        .Select(coord => coord
                            .Split(",")
                            .Select(int.Parse)
                            .ToArray())
                        .ToArray());

        char[,] cave = new char[COLUMNS, ROWS];

        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLUMNS; x++)
            {
                cave[x, y] = '.';
            }
        }

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

        return cave;
    }

    private void PrintCave(char[,] cave)
    {
        int minX = Enumerable.Range(0, COLUMNS - 1).First(x => Enumerable.Range(0, ROWS - 1).Any(y => cave[x, y] != '.'));
        int maxX = Enumerable.Range(minX + 1, COLUMNS - minX - 1).First(x => Enumerable.Range(0, ROWS - 1).All(y => cave[x, y] == '.')) - 1;

        int minY = 0;
        int maxY = Enumerable.Range(0, ROWS - 1).Reverse().First(y => Enumerable.Range(0, COLUMNS - 1).Any(x => cave[x, y] != '.')) + 1;

        Console.Clear();
        for (int y = minY; y < maxY; y++)
        {
            Console.Write(y);
            for (int x = minX; x < maxX; x++)
            {
                Console.Write(cave[x, y]);
            }
            Console.Write("\r\n");
        }
    }

    private int Run(char[,] cave, bool debug)
    {
        int x = 500, y = 0;
        int maxY = Enumerable.Range(0, ROWS - 1).Reverse().First(y => Enumerable.Range(0, COLUMNS - 1).Any(x => cave[x, y] != '.')) + 1;

        int sandDropped = 0;
        while (!TickSand(cave, x, y, maxY))
        {
            sandDropped++;
            if (debug)
            {
                PrintCave(cave);
                Task.Delay(200).Wait();
            }
        }

        return sandDropped;
    }

    private bool TickSand(char[,] cave, int x, int y, int maxY)
    {
        if (y + 1 > maxY)
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