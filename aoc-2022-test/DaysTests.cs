namespace aoc_2022_test;

public class DaysTests
{
    [Theory]
    [InlineData(1, 1, "examples", "24000")]
    [InlineData(1, 1, "actual", "72478")]
    [InlineData(1, 2, "examples", "45000")]
    [InlineData(1, 2, "actual", "210367")]
    [InlineData(2, 1, "examples", "15")]
    [InlineData(2, 1, "actual", "14827")]
    [InlineData(2, 2, "examples", "12")]
    [InlineData(2, 2, "actual", "13889")]
    [InlineData(3, 1, "examples", "157")]
    [InlineData(3, 1, "actual", "7980")]
    [InlineData(3, 2, "examples", "70")]
    [InlineData(3, 2, "actual", "2881")]
    [InlineData(4, 1, "examples", "2")]
    [InlineData(4, 1, "actual", "441")]
    [InlineData(4, 2, "examples", "4")]
    [InlineData(4, 2, "actual", "861")]
    [InlineData(5, 1, "examples", "CMZ")]
    [InlineData(5, 1, "actual", "TPGVQPFDH")]
    [InlineData(5, 2, "examples", "MCD")]
    [InlineData(5, 2, "actual", "DMRDFRHHH")]
    [InlineData(6, 1, "examples", "11")]
    [InlineData(6, 1, "actual", "1816")]
    [InlineData(6, 2, "examples", "26")]
    [InlineData(6, 2, "actual", "2625")]
    [InlineData(7, 1, "examples", "95437")]
    [InlineData(7, 1, "actual", "1427048")]
    [InlineData(7, 2, "examples", "24933642")]
    [InlineData(7, 2, "actual", "2940614")]
    [InlineData(8, 1, "examples", "21")]
    [InlineData(8, 1, "actual", "1843")]
    [InlineData(8, 2, "examples", "8")]
    [InlineData(8, 2, "actual", "180000")]
    [InlineData(9, 1, "examples", "88")]
    [InlineData(9, 1, "actual", "6181")]
    [InlineData(9, 2, "examples", "36")]
    [InlineData(9, 2, "actual", "2386")]
    [InlineData(10, 1, "examples", "13140")]
    [InlineData(10, 1, "actual", "17940")]
    [InlineData(10, 2, "examples", @"
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
")]
    [InlineData(10, 2, "actual", @"
####..##..###...##....##.####...##.####.
...#.#..#.#..#.#..#....#.#.......#....#.
..#..#....###..#..#....#.###.....#...#..
.#...#....#..#.####....#.#.......#..#...
.....#..#.#..#.#..#.#..#.#....#..#.#....
####..##..###..#..#..##..#.....##..####.
")]

    public void TestAll(int day, int part, string folder, string expected)
    {
        // Arrange
        IDay dayObject = (IDay)Activator.CreateInstance(Utils.GetType($"aoc_2022.Day{day}"))!;

        // Act
        string actual = part == 1
            ? dayObject.Part1($"./{folder}/{day}.txt")
            : dayObject.Part2($"./{folder}/{day}.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}