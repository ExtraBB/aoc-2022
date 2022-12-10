using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day6Tests
{
    [Theory]
    [InlineData("examples", "11")]
    [InlineData("actual", "1816")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day6 day = new Day6();

        // Act
        string actual = day.Part1($"./{folder}/6.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "26")]
    [InlineData("actual", "2625")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day6 day = new Day6();

        // Act
        string actual = day.Part2($"./{folder}/6.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}