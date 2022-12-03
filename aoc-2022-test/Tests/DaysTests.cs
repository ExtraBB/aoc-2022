using System.Reflection;

namespace aoc_2022_test.Tests;

public class DaysTests
{
    [Theory]
    [InlineData(1, 1, "example", "24000")]
    [InlineData(1, 1, "actual", "72478")]
    [InlineData(1, 2, "example", "45000")]
    [InlineData(1, 2, "actual", "210367")]
    [InlineData(2, 1, "example", "15")]
    [InlineData(2, 1, "actual", "14827")]
    [InlineData(2, 2, "example", "12")]
    [InlineData(2, 2, "actual", "13889")]
    [InlineData(3, 1, "example", "157")]
    [InlineData(3, 1, "actual", "7980")]
    [InlineData(3, 2, "example", "70")]
    [InlineData(3, 2, "actual", "2881")]
    public void TestAll(int day, int part, string type, string expected)
    {
        // Arrange
        IDay dayObject = (IDay)Activator.CreateInstance(GetType($"aoc_2022.Day{day}"))!;

        // Act
        string actual = part == 1
            ? dayObject.Part1($"./Files/{day}-{type}.txt")
            : dayObject.Part2($"./Files/{day}-{type}.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    private static Type GetType(string typeName)
    {
        var type = Type.GetType(typeName);
        if (type != null) return type;
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = a.GetType(typeName);
            if (type != null)
                return type;
        }
        return null;
    }
}