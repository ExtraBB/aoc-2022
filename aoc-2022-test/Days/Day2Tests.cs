using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day2Tests
{
    [Theory]
    [InlineData("examples", "15")]
    [InlineData("actual", "14827")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day2 day = new Day2();

        // Act
        string actual = day.Part1($"./{folder}/2.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "12")]
    [InlineData("actual", "13889")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day2 day = new Day2();

        // Act
        string actual = day.Part2($"./{folder}/2.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}