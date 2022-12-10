using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day3Tests
{
    [Theory]
    [InlineData("examples", "157")]
    [InlineData("actual", "7980")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day3 day = new Day3();

        // Act
        string actual = day.Part1($"./{folder}/3.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "70")]
    [InlineData("actual", "2881")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day3 day = new Day3();

        // Act
        string actual = day.Part2($"./{folder}/3.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}