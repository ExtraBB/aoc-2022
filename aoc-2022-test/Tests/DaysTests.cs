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
    [InlineData(4, 1, "example", "2")]
    [InlineData(4, 1, "actual", "441")]
    [InlineData(4, 2, "example", "4")]
    [InlineData(4, 2, "actual", "861")]
    [InlineData(5, 1, "example", "CMZ")]
    [InlineData(5, 1, "actual", "TPGVQPFDH")]
    [InlineData(5, 2, "example", "MCD")]
    [InlineData(5, 2, "actual", "DMRDFRHHH")]
    [InlineData(6, 1, "example", "11")]
    [InlineData(6, 1, "actual", "1816")]
    [InlineData(6, 2, "example", "26")]
    [InlineData(6, 2, "actual", "2625")]
    [InlineData(7, 1, "example", "95437")]
    [InlineData(7, 1, "actual", "1427048")]
    [InlineData(7, 2, "example", "24933642")]
    [InlineData(7, 2, "actual", "2940614")]
    [InlineData(8, 1, "example", "21")]
    [InlineData(8, 1, "actual", "1843")]
    [InlineData(8, 2, "example", "8")]
    [InlineData(8, 2, "actual", "180000")]
    public void TestAll(int day, int part, string type, string expected)
    {
        // Arrange
        IDay dayObject = (IDay)Activator.CreateInstance(Utils.GetType($"aoc_2022.Day{day}"))!;

        // Act
        string actual = part == 1
            ? dayObject.Part1($"./Files/{day}-{type}.txt")
            : dayObject.Part2($"./Files/{day}-{type}.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}