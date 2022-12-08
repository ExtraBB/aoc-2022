using aoc_2022.DataStructures;

namespace aoc_2022
{
    public class Day7 : IDay
    {
        public string Part1(string filePath)
        {
            TreeNode<int> tree = BuildTree(filePath);
            List<int> sizes = new List<int>();
            FindAllFolderSizes(tree, sizes);
            return sizes.Where(size => size <= 100_000).Sum().ToString();
        }

        public string Part2(string filePath)
        {
            TreeNode<int> tree = BuildTree(filePath);
            List<int> sizes = new List<int>();
            FindAllFolderSizes(tree, sizes);

            int missingSpace = 30_000_000 - (70_000_000 - sizes.Max());
            return sizes.Order().First(c => c >= missingSpace).ToString();
        }

        private int FindAllFolderSizes(TreeNode<int> tree, List<int> sizes)
        {
            if (tree.ChildNodes.Any())
            {
                int childSize = tree.ChildNodes.Values.Sum(child => FindAllFolderSizes(child, sizes));
                sizes.Add(childSize);

                return childSize;
            }

            return tree.Value;
        }

        private TreeNode<int> BuildTree(string filePath)
        {
            TreeNode<int> rootNode = new(0, "/", null);
            TreeNode<int> currentNode = rootNode;

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (line == "$ cd ..")
                {
                    currentNode = currentNode.Parent!;
                }
                else if (line == "$ cd /")
                {
                    currentNode = rootNode;
                }
                else if (line.StartsWith("$ cd "))
                {
                    string folder = line.Substring("$ cd ".Length);
                    currentNode = currentNode.GetOrCreateChild(0, folder);
                }
                else if (line.StartsWith("$"))
                {
                    // ignore
                }
                else if (line.StartsWith("dir "))
                {
                    string folder = line.Substring("dir ".Length);

                    currentNode.CreateChild(0, folder);
                }
                else
                {
                    var split = line.Split(" ");
                    currentNode.CreateChild(int.Parse(split[0]), split[1]);
                }
            }

            return rootNode;
        }
    }
}
