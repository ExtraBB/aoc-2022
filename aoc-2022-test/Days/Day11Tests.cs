using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day11Tests
{
    [Theory]
    [InlineData("examples", "10605")]
    [InlineData("actual", "111210")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day11 day = new Day11();

        // Act
        string actual = day.Part1($"./{folder}/11.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "2713310158")]
    [InlineData("actual", "15447387620")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day11 day = new Day11();

        // Act
        string actual = day.Part2($"./{folder}/11.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}