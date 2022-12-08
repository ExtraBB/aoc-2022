using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022.DataStructures
{
    public class TreeNode<T>
    {
        public T Value { get; }
        public string Name { get; }
        public Dictionary<string, TreeNode<T>> ChildNodes { get; } = new Dictionary<string, TreeNode<T>>();
        public TreeNode<T>? Parent { get; }

        public TreeNode(T value, string name, TreeNode<T>? parent)
        {
            Value = value;
            Name = name;
            Parent = parent;
        }

        public void CreateChild(T value, string name)
        {
            ChildNodes.Add(name, new TreeNode<T>(value, name, this));
        }

        public TreeNode<T> GetOrCreateChild(T value,string name)
        {
            if (!ChildNodes.ContainsKey(name))
            {
                CreateChild(value, name);
            }
            return ChildNodes[name];
        }
    }
}
