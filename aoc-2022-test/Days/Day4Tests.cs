using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day4Tests
{
    [Theory]
    [InlineData("examples", "2")]
    [InlineData("actual", "441")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day4 day = new Day4();

        // Act
        string actual = day.Part1($"./{folder}/4.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "4")]
    [InlineData("actual", "861")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day4 day = new Day4();

        // Act
        string actual = day.Part2($"./{folder}/4.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}