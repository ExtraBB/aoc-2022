using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022.DataStructures
{
    public class TreeNode
    {
        public string Name { get; }
        public Dictionary<string, TreeNode> ChildNodes { get; } = new Dictionary<string, TreeNode>();
        public TreeNode? Parent { get; }

        public TreeNode(string name, TreeNode? parent)
        {
            Name = name;
            Parent = parent;
        }

        public void CreateChild(string name)
        {
            ChildNodes.Add(name, new TreeNode(name, this));
        }

        public TreeNode GetOrCreateChild(string name)
        {
            if (!ChildNodes.ContainsKey(name))
            {
                CreateChild(name);
            }
            return ChildNodes[name];
        }
    }
}
