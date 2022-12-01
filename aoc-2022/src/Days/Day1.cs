using aoc_2022.Utils;

namespace aoc_2022.Days;

public class Day1 : IDay
{
    public string RunPart1(string filePath)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return calories[0].ToString();
    }

    public string RunPart2(string filePath)
    {
        var calories = ExtractOrderedCalorieTotalsFromFile(filePath);
        return (calories[0] + calories[1] + calories[2]).ToString();
    }

    private List<int> ExtractOrderedCalorieTotalsFromFile(string filePath)
    {
        var groups = FileUtils.ReadLineGroups(filePath, int.Parse);
        return groups.Select(g => g.Sum()).OrderByDescending(g => g).ToList();
    }
}
