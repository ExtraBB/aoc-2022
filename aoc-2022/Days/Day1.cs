namespace aoc_2022.Days;

public class Day1 : IDay
{
    public string Part1(string filePath, bool debug = false)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories.First().ToString();
    }

    public string Part2(string filePath, bool debug = false)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories.Take(3).Sum().ToString();
    }

    private IEnumerable<int> ExtractOrderedCalorieTotalsFromFile(string filePath)
    {
        return File.ReadAllText(filePath)
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(group => group
                .Split(Environment.NewLine)
                .Select(int.Parse)
                .Sum())
            .OrderByDescending(g => g);
    }
}
