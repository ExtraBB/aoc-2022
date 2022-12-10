namespace aoc_2022_test.Tests;

public class DaysTests
{
    [Theory]
    [InlineData(1, 1, "Examples", "24000")]
    [InlineData(1, 1, "Actual", "72478")]
    [InlineData(1, 2, "Examples", "45000")]
    [InlineData(1, 2, "Actual", "210367")]
    [InlineData(2, 1, "Examples", "15")]
    [InlineData(2, 1, "Actual", "14827")]
    [InlineData(2, 2, "Examples", "12")]
    [InlineData(2, 2, "Actual", "13889")]
    [InlineData(3, 1, "Examples", "157")]
    [InlineData(3, 1, "Actual", "7980")]
    [InlineData(3, 2, "Examples", "70")]
    [InlineData(3, 2, "Actual", "2881")]
    [InlineData(4, 1, "Examples", "2")]
    [InlineData(4, 1, "Actual", "441")]
    [InlineData(4, 2, "Examples", "4")]
    [InlineData(4, 2, "Actual", "861")]
    [InlineData(5, 1, "Examples", "CMZ")]
    [InlineData(5, 1, "Actual", "TPGVQPFDH")]
    [InlineData(5, 2, "Examples", "MCD")]
    [InlineData(5, 2, "Actual", "DMRDFRHHH")]
    [InlineData(6, 1, "Examples", "11")]
    [InlineData(6, 1, "Actual", "1816")]
    [InlineData(6, 2, "Examples", "26")]
    [InlineData(6, 2, "Actual", "2625")]
    [InlineData(7, 1, "Examples", "95437")]
    [InlineData(7, 1, "Actual", "1427048")]
    [InlineData(7, 2, "Examples", "24933642")]
    [InlineData(7, 2, "Actual", "2940614")]
    [InlineData(8, 1, "Examples", "21")]
    [InlineData(8, 1, "Actual", "1843")]
    [InlineData(8, 2, "Examples", "8")]
    [InlineData(8, 2, "Actual", "180000")]
    [InlineData(9, 1, "Examples", "88")]
    [InlineData(9, 1, "Actual", "6181")]
    [InlineData(9, 2, "Examples", "36")]
    [InlineData(9, 2, "Actual", "2386")]
    [InlineData(10, 1, "Examples", "13140")]
    [InlineData(10, 1, "Actual", "17940")]
    [InlineData(10, 2, "Examples", "##..##..##..##..##..##..##..##..##..##..\r\n###...###...###...###...###...###...###.\r\n####....####....####....####....####....\r\n#####.....#####.....#####.....#####.....\r\n######......######......######......####\r\n#######.......#######.......#######.....\r\n")]
    [InlineData(10, 2, "Actual", "####..##..###...##....##.####...##.####.\r\n...#.#..#.#..#.#..#....#.#.......#....#.\r\n..#..#....###..#..#....#.###.....#...#..\r\n.#...#....#..#.####....#.#.......#..#...\r\n.....#..#.#..#.#..#.#..#.#....#..#.#....\r\n####..##..###..#..#..##..#.....##..####.\r\n")]
    public void TestAll(int day, int part, string folder, string expected)
    {
        // Arrange
        IDay dayObject = (IDay)Activator.CreateInstance(Utils.GetType($"aoc_2022.Day{day}"))!;

        // Act
        string actual = part == 1
            ? dayObject.Part1($"./Inputs/{folder}/{day}.txt")
            : dayObject.Part2($"./Inputs/{folder}/{day}.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}