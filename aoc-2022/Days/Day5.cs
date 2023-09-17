using System.Security.Cryptography;
using System.Text.RegularExpressions;
using aoc_2022.Utils;

namespace aoc_2022.Days
{
    public class Day5 : IDay
    {
        Regex instructionRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");

        public string Part1(string filePath)
        {
            return ProcessInstructions(filePath, 1);
        }

        public string Part2(string filePath)
        {
            return ProcessInstructions(filePath, 2);
        }

        private string ProcessInstructions(string filePath, int part)
        {
            var split = File.ReadAllText(filePath).Split(Environment.NewLine + Environment.NewLine);
            var stacks = ParseStacks(split[0]);
            var instructions = ParseInstructions(split[1]);

            foreach (int[] instruction in instructions)
            {
                if (instruction is [int amount, int from, int to])
                {
                    while (to - 1 > stacks.Count)
                    {
                        stacks.Add(new Stack<char>());
                    }

                    if (part == 1)
                    {
                        MoveFromStack(stacks[from - 1], stacks[to - 1], amount);
                    }
                    else
                    {
                        Stack<char> intermediateStack = new Stack<char>();
                        MoveFromStack(stacks[from - 1], intermediateStack, amount);
                        MoveFromStack(intermediateStack, stacks[to - 1], amount);
                    }
                }
            }

            return stacks.Aggregate("", (a, b) => a + b.Peek().ToString());
        }

        private List<Stack<char>> ParseStacks(string input)
        {
            var lines = input.Split(Environment.NewLine);
            return Enumerable
                .Range(0, lines.Last().Length / 4 + 1)
                .Select(i => new Stack<char>(lines.Select(l => l[i * 4 + 1]).Where(char.IsLetter).Reverse()))
                .ToList();
        }

        private IEnumerable<int[]> ParseInstructions(string input)
        {
            return input
                .Split(Environment.NewLine)
                .Select(line => ParserUtils.ParseGroupsFromStringAndConvert(instructionRegex, line, int.Parse));
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
