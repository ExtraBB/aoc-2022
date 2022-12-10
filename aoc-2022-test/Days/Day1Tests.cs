using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day1Tests
{
    [Theory]
    [InlineData("examples", "24000")]
    [InlineData("actual", "72478")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day1 day = new Day1();

        // Act
        string actual = day.Part1($"./{folder}/1.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "45000")]
    [InlineData("actual", "210367")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day1 day = new Day1();

        // Act
        string actual = day.Part2($"./{folder}/1.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}