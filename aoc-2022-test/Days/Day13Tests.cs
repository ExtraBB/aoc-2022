using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day13Tests
{
    [Theory]
    [InlineData("examples", "13")]
    [InlineData("actual", "6070")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day13 day = new Day13();

        // Act
        string actual = day.Part1($"./{folder}/13.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "140")]
    [InlineData("actual", "20758")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day13 day = new Day13();

        // Act
        string actual = day.Part2($"./{folder}/13.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}