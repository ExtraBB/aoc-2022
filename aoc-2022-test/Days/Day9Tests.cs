using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day9Tests
{
    [Theory]
    [InlineData("examples", "88")]
    [InlineData("actual", "6181")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day9 day = new Day9();

        // Act
        string actual = day.Part1($"./{folder}/9.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "36")]
    [InlineData("actual", "2386")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day9 day = new Day9();

        // Act
        string actual = day.Part2($"./{folder}/9.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}