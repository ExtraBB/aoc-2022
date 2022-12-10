using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day8Tests
{
    [Theory]
    [InlineData("examples", "21")]
    [InlineData("actual", "1843")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day8 day = new Day8();

        // Act
        string actual = day.Part1($"./{folder}/8.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "8")]
    [InlineData("actual", "180000")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day8 day = new Day8();

        // Act
        string actual = day.Part2($"./{folder}/8.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}