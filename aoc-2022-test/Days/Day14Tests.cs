using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day14Tests
{
    [Theory]
    [InlineData("examples", "24")]
    [InlineData("actual", "1078")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day14 day = new Day14();

        // Act
        string actual = day.Part1($"./{folder}/14.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "93")]
    [InlineData("actual", "30157")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day14 day = new Day14();

        // Act
        string actual = day.Part2($"./{folder}/14.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}