using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2022
{
    public class Day5 : IDay
    {
        Regex instructionRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");

        public string Part1(string filePath)
        {
            string text = File.ReadAllText(filePath);
            var split = text.Split("\r\n\r\n");

            List<Stack<char>> stacks = CreateStacks(split[0]);
            foreach(string instruction in split[1].Split("\r\n"))
            {
                ProcessInstructionOneByOne(instruction, stacks);
            }

            return stacks.Aggregate("", (a, b) => a + b.Peek().ToString());
        }

        public string Part2(string filePath)
        {
            string text = File.ReadAllText(filePath);
            var split = text.Split("\r\n\r\n");

            List<Stack<char>> stacks = CreateStacks(split[0]);
            foreach (string instruction in split[1].Split("\r\n"))
            {
                ProcessInstructionAsGroup(instruction, stacks);
            }

            return stacks.Aggregate("", (a, b) => a + b.Peek().ToString());
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

        private void ProcessInstructionOneByOne(string instruction, List<Stack<char>> stacks)
        {
            int[] numbers = Helpers.ParseGroupsFromStringAndConvert(instructionRegex, instruction, int.Parse);

            while (numbers[2] - 1 > stacks.Count)
            {
                stacks.Add(new Stack<char>());
            }

            MoveFromStack(stacks[numbers[1] - 1], stacks[numbers[2] - 1], numbers[0]);
        }

        private void MoveFromStack(Stack<char> a, Stack<char> b, int numToMove) 
        {
            for (int i = 0; i < numToMove; i++)
            {
                a.Push(b.Pop());
            }
        }

        private void ProcessInstructionAsGroup(string instruction, List<Stack<char>> stacks)
        {
            int[] numbers = Helpers.ParseGroupsFromStringAndConvert(instructionRegex, instruction, int.Parse);

            Stack<char> intermediateStack = new Stack<char>();

            while (numbers[2] - 1 > stacks.Count)
            {
                stacks.Add(new Stack<char>());
            }

            MoveFromStack(stacks[numbers[1] - 1], intermediateStack, numbers[0]);
            MoveFromStack(intermediateStack, stacks[numbers[2] - 1], numbers[0]);
        }
    }
}
