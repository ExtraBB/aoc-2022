using aoc_2022.Days;

namespace aoc_2022_test.Days;

public class Day10Tests
{
    [Theory]
    [InlineData("examples", "13140")]
    [InlineData("actual", "17940")]
    public void Part1(string folder, string expected)
    {
        // Arrange
        Day10 day = new Day10();

        // Act
        string actual = day.Part1($"./{folder}/10.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("examples", @"
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
")]
    [InlineData("actual", @"
####..##..###...##....##.####...##.####.
...#.#..#.#..#.#..#....#.#.......#....#.
..#..#....###..#..#....#.###.....#...#..
.#...#....#..#.####....#.#.......#..#...
.....#..#.#..#.#..#.#..#.#....#..#.#....
####..##..###..#..#..##..#.....##..####.
")]
    public void Part2(string folder, string expected)
    {
        // Arrange
        Day10 day = new Day10();

        // Act
        string actual = day.Part2($"./{folder}/10.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}