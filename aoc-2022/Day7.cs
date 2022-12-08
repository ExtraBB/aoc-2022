using aoc_2022.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
    public class Accumulator
    {
        public int Total { get; set; }
    }

    public class Day7 : IDay
    {
        public string Part1(string filePath)
        {
            TreeNode<int> tree = BuildTree(filePath);
            Accumulator acc = new Accumulator();
            FindTotalFolderSizes(tree, 100_000, acc);
            return acc.Total.ToString();
        }

        public string Part2(string filePath)
        {
            TreeNode<int> tree = BuildTree(filePath);
            List<int> sizes = new List<int>();
            FindAllFolderSizes(tree, sizes);

            int missingSpace = 30_000_000 - (70_000_000 - sizes.Max());

            return sizes.Order().First(c => c >= missingSpace).ToString();
        }

        private int FindTotalFolderSizes(TreeNode<int> tree, int maxFolderSize, Accumulator accumulator)
        {
            if (tree.ChildNodes.Any())
            {
                int childSize = tree.ChildNodes.Values.Sum(child => FindTotalFolderSizes(child, maxFolderSize, accumulator));
                if (childSize < maxFolderSize)
                {
                    accumulator.Total += childSize;
                }

                return childSize;
            }
            
            return tree.Value;
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
