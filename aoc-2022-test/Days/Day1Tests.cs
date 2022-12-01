namespace aoc_2022_test;

public class Day1Tests
{
    [Theory]
    [InlineData("../../../../files/1-example.txt", "24000")]
    [InlineData("../../../../files/1-actual.txt", "72478")]
    public void Part1(string path, string expected)
    {
        // Arrange
        Day1 day = new Day1();

        // Act
        string actual = day.RunPart1(Path.GetFullPath(path));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("../../../../files/1-example.txt", "45000")]
    [InlineData("../../../../files/1-actual.txt", "210367")]
    public void Part2(string path, string expected)
    {
        // Arrange
        Day1 day = new Day1();

        // Act
        string actual = day.RunPart2(Path.GetFullPath(path));

        // Assert
        Assert.Equal(expected, actual);
    }
}