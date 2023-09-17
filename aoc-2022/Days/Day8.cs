namespace aoc_2022.Days
{
    public class Day8 : IDay
    {
        public string Part1(string filePath, bool debug = false)
        {
            var grid = ParseGrid(filePath);

            int visible = 0;

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (TreesVisibleInDirection(grid, x, y, -1, 0, false) == x ||
                        TreesVisibleInDirection(grid, x, y, 1, 0, false) == grid.GetLength(0) - x - 1 ||
                        TreesVisibleInDirection(grid, x, y, 0, -1, false) == y ||
                        TreesVisibleInDirection(grid, x, y, 0, 1, false) == grid.GetLength(1) - y - 1)
                    {
                        visible++;
                    }
                }
            }

            return visible.ToString();
        }

        public string Part2(string filePath, bool debug = false)
        {
            var grid = ParseGrid(filePath);
            int maxScore = 0;

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    int scenicScore =
                        TreesVisibleInDirection(grid, x, y, -1, 0, true) *
                        TreesVisibleInDirection(grid, x, y, 1, 0, true) *
                        TreesVisibleInDirection(grid, x, y, 0, -1, true) *
                        TreesVisibleInDirection(grid, x, y, 0, 1, true);

                    maxScore = Math.Max(maxScore, scenicScore);
                }
            }

            return maxScore.ToString();
        }

        private int[,] ParseGrid(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            int[,] grid = new int[lines[0].Length, lines.Length];

            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    grid[x, y] = lines[y][x] - '0';
                }
            }

            return grid;
        }

        private int TreesVisibleInDirection(int[,] grid, int x, int y, int dx, int dy, bool countBlockingTree)
        {
            int numTreesVisible = 0;
            int nextX = x + dx;
            int nextY = y + dy;
            while (nextX >= 0 && nextX < grid.GetLength(0) && nextY >= 0 && nextY < grid.GetLength(1))
            {
                if (grid[nextX, nextY] >= grid[x, y])
                {
                    if (countBlockingTree)
                    {
                        numTreesVisible++;
                    }
                    return numTreesVisible;
                }

                nextX += dx;
                nextY += dy;
                numTreesVisible++;
            }

            return numTreesVisible;
        }
    }
}
