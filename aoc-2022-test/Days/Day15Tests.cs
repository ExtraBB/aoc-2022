using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day15Tests
{
    [Theory]
    [InlineData("examples", "26", 10)]
    [InlineData("actual", "5508234", 2000000)]
    public void Part1(string folder, string expected, int target)
    {
        // Arrange
        Day15 day = new Day15();
        day.SetTarget(target);

        // Act
        string actual = day.Part1($"./{folder}/15.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", "56000011", 20)]
    // [InlineData("actual", "10457634860779", 4000000)] // Long running
    public void Part2(string folder, string expected, int maxBounds)
    {
        // Arrange
        Day15 day = new Day15();
        day.SetMaxBounds(maxBounds);

        // Act
        string actual = day.Part2($"./{folder}/15.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

}