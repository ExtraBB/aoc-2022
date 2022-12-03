using BenchmarkDotNet.Attributes;

namespace aoc_2022;

public class Day1 : IDay
{
    public string Part1(string filePath)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories.First().ToString();
    }

    public string Part2(string filePath)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories.Take(3).Sum().ToString();
    }

    private IEnumerable<int> ExtractOrderedCalorieTotalsFromFile(string filePath)
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
