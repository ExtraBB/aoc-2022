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
        return File.ReadAllText(filePath)
            .Split("\r\n\r\n")
            .Select(group => group
                .Split("\r\n")
                .Select(int.Parse)
                .Sum())
            .OrderByDescending(g => g)
            .ToList();
    }
}
