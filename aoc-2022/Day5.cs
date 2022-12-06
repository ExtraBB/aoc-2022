using System.Text.RegularExpressions;

namespace aoc_2022
{
    public class Day5 : IDay
    {
        Regex instructionRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");

        public string Part1(string filePath)
        {
            return Process(filePath, 1);
        }

        public string Part2(string filePath)
        {
            return Process(filePath, 2);
        }

        private string Process(string filePath, int part)
        {
            (List<Stack<char>> stacks, IEnumerable<int[]> instructions) = Parse(filePath);

            foreach (int[] instruction in instructions)
            {
                while (instruction[2] - 1 > stacks.Count)
                {
                    stacks.Add(new Stack<char>());
                }

                if (part == 1)
                {
                    MoveFromStack(stacks[instruction[1] - 1], stacks[instruction[2] - 1], instruction[0]);
                }
                else
                {
                    Stack<char> intermediateStack = new Stack<char>();
                    MoveFromStack(stacks[instruction[1] - 1], intermediateStack, instruction[0]);
                    MoveFromStack(intermediateStack, stacks[instruction[2] - 1], instruction[0]);
                }
            }

            return stacks.Aggregate("", (a, b) => a + b.Peek().ToString());
        }

        private (List<Stack<char>> stacks, IEnumerable<int[]> instructions) Parse(string filePath)
        {
            string text = File.ReadAllText(filePath);
            var split = text.Split("\r\n\r\n");

            List<Stack<char>> stacks = CreateStacks(split[0]);
            IEnumerable<int[]> instructions = split[1]
                .Split("\r\n")
                .Select(line => Helpers.ParseGroupsFromStringAndConvert(instructionRegex, line, int.Parse));

            return (stacks, instructions);
        }

        private List<Stack<char>> CreateStacks(string input)
        {
            var lines = input.Split("\r\n");
            int numStacks = (lines.Last().Length - 3) / 4 + 1;
            List<Stack<char>> stacks = new List<Stack<char>>();
            for (int i = 0; i < numStacks; i++)
            {
                stacks.Add(new Stack<char>());
            }

            foreach(string line in lines.Take(lines.Length - 1).Reverse())
            {
                for(int i = 0; i < line.Length; i += 4)
                {
                    if (char.IsLetter(line[i + 1]))
                    {
                        stacks[i / 4].Push(line[i + 1]);
                    }
                }
            }

            return stacks;
        }

        private void MoveFromStack(Stack<char> from, Stack<char> to, int numToMove) 
        {
            for (int i = 0; i < numToMove; i++)
            {
                to.Push(from.Pop());
            }
        }
    }
}
