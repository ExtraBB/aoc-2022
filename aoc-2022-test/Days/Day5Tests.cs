using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day5Tests
{
    [Theory]
    [InlineData("examples", "CMZ")]
    [InlineData("actual", "TPGVQPFDH")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day5 day = new Day5();

        // Act
        string actual = day.Part1($"./{folder}/5.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "MCD")]
    [InlineData("actual", "DMRDFRHHH")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day5 day = new Day5();

        // Act
        string actual = day.Part2($"./{folder}/5.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}