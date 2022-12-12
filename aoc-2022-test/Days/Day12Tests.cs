using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day12Tests
{
    [Theory]
    [InlineData("examples", "31")]
    [InlineData("actual", "534")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day12 day = new Day12();

        // Act
        string actual = day.Part1($"./{folder}/12.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "29")]
    [InlineData("actual", "525")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day12 day = new Day12();

        // Act
        string actual = day.Part2($"./{folder}/12.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}