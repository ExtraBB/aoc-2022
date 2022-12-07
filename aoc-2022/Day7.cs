using aoc_2022.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2022
{
    public class Day7 : IDay
    {
        public string Part1(string filePath)
        {
            TreeNode rootNode = new("/", null);
            TreeNode currentNode = rootNode;

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
                    currentNode = currentNode.GetOrCreateChild(folder);
                }
                else if (line.StartsWith("$"))
                {
                    // ignore
                }
                else if (line.StartsWith("dir "))
                {
                    string folder = line.Substring("dir ".Length);

                    currentNode.CreateChild(folder);
                }
            }
        }

        public string Part2(string filePath)
        {
            throw new NotImplementedException();
        }

        private void ProcessInstruction(string instruction)
        {

        }
    }

    public class Tree 
}
