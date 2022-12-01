using System.Reflection;

namespace aoc_2022_test.Tests;

public class DaysTests
{
    [Theory]
    [InlineData(1, 1, "example", "24000")]
    [InlineData(1, 2, "example", "45000")]
    [InlineData(1, 1, "actual", "72478")]
    [InlineData(1, 2, "actual", "210367")]
    public void TestAll(int day, int part, string type, string expected)
    {
        // Arrange
        MethodInfo method = GetType($"aoc_2022.Days.Day{day}")!.GetMethod($"Part{part}")!;

        // Act
        string actual = (string)method.Invoke(null, new[] { $"./Files/{day}-{type}.txt" })!;

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