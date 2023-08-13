using System.Diagnostics;
using aoc_2022.Utils;

namespace aoc_2022.Days;

public class Day13 : IDay
{
    public string Part1(string filePath)
    {
        var text = File.ReadAllText(filePath);
        var pairs = text.Split("\n\n");
        int result = 0, index = 1;
        foreach (string pair in pairs)
        {
            var lines = pair.Split("\n");
            var left = ParseLine(lines[0]);
            var right = ParseLine(lines[1]);

            if (CompareOrder(left, right) < 1)
            {
                Console.WriteLine(index);
                result += index;
            }

            index++;
        }

        return result.ToString();
    }

    public string Part2(string filePath)
    {
        throw new NotImplementedException();
    }

    private int CompareOrder(TreeNode left, TreeNode right)
    {
        if (left.IsLeaf() && right.IsLeaf())
        {
            return Math.Sign(left.Value - right.Value);
        }
        else if (!left.IsLeaf() && right.IsLeaf())
        {
            return CompareOrder(left, new TreeNode(new List<TreeNode>() { right }, -1));
        }
        else if (left.IsLeaf() && !right.IsLeaf())
        {
            return CompareOrder(new TreeNode(new List<TreeNode>() { left }, -1), right);
        }
        else
        {
            for (int i = 0; i < left.Children.Count; i++)
            {
                if (i >= right.Children.Count)
                {
                    return 1;
                }
                int comparison = CompareOrder(left.Children[i], right.Children[i]);
                if (comparison != 0)
                {
                    return comparison;
                }
            }
            return 0;
        }
    }

    private TreeNode ParseLine(string line)
    {
        TreeNode root = new TreeNode(new List<TreeNode>(), -1);
        int start = 1;
        BuildTree(root, line, ref start);
        return root;
    }

    private void BuildTree(TreeNode parentNode, string line, ref int i)
    {
        while (i < line.Length)
        {
            char c = line[i];
            i++;
            if (c == '[')
            {
                TreeNode newNode = new TreeNode(new List<TreeNode>(), -1);
                BuildTree(newNode, line, ref i);
                parentNode.Children.Add(newNode);
            }
            else if (c == ']')
            {
                return;
            }
            else if (char.IsDigit(c))
            {
                parentNode.Children.Add(new TreeNode(new List<TreeNode>(), c - '0'));
            }
        }
    }

}

internal record TreeNode(List<TreeNode> Children, int Value);

internal static class TreeNodeExtensions
{
    internal static bool IsLeaf(this TreeNode node)
    {
        return node.Value != -1;
    }
}