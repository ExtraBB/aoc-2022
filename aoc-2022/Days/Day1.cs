using BenchmarkDotNet.Attributes;

namespace aoc_2022.Days;

public static class Day1
{
    public static string Part1(string filePath)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories.First().ToString();
    }

    public static string Part2(string filePath)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories.Take(3).Sum().ToString();
    }

    private static IEnumerable<int> ExtractOrderedCalorieTotalsFromFile(string filePath)
    {
        return File.ReadAllText(filePath)
            .Split("\r\n\r\n")
            .Select(group => group
                .Split("\r\n")
                .Select(int.Parse)
                .Sum())
            .OrderByDescending(g => g);
    }
}
