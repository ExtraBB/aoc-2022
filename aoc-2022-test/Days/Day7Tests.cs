using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day7Tests
{
    [Theory]
    [InlineData("examples", "95437")]
    [InlineData("actual", "1427048")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day7 day = new Day7();

        // Act
        string actual = day.Part1($"./{folder}/7.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "24933642")]
    [InlineData("actual", "2940614")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day7 day = new Day7();

        // Act
        string actual = day.Part2($"./{folder}/7.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}