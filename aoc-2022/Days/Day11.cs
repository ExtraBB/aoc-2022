using aoc_2022.Utils;
using System.Text.RegularExpressions;

namespace aoc_2022.Days
{
    public class Day11 : IDay
    {
        Regex itemsRegex = new Regex(@".* (\d+,?)*");
        public string Part1(string filePath)
        {
            List<Monkey> monkeys = ParseMonkeys(filePath);

            for (int i = 0; i < 20; i++)
            {
                foreach(var monkey in monkeys)
                {
                    monkey.PerformRound();
                }
            }

            var ordered = monkeys.OrderByDescending(m => m.NumberOfInspections).ToList();

            return (ordered[0].NumberOfInspections * ordered[1].NumberOfInspections).ToString();
        }

        public string Part2(string filePath)
        {
            throw new NotImplementedException();
        }

        private List<Monkey> ParseMonkeys(string filePath)
        {
            List<Monkey> monkeys = new List<Monkey>();
            Dictionary<int, int> PositiveTestMonkeys = new Dictionary<int, int>();
            Dictionary<int, int> NegativeTestMonkeys = new Dictionary<int, int>();

            int counter = 0;
            foreach(var monkey in File.ReadAllText(filePath).Split(Environment.NewLine + Environment.NewLine))
            {
                var lines = monkey.Split(Environment.NewLine);
                var items = lines[1].Split(":")[1].Split(",").Select(x => int.Parse(x.Trim()));
                var operation = ParseOperation(lines[2].Split(":")[1].Trim());
                var test = (int i) => i % int.Parse(lines[3].Split(" ").Last()) == 0;

                PositiveTestMonkeys[counter] = int.Parse(lines[4].Split(" ").Last());
                NegativeTestMonkeys[counter] = int.Parse(lines[5].Split(" ").Last());

                monkeys.Add(new Monkey(items, operation, test));
                counter++;
            }

            for(int i = 0; i < counter; i++)
            {
                monkeys[i].PositiveTestMonkey = monkeys[PositiveTestMonkeys[i]];
                monkeys[i].NegativeTestMonkey = monkeys[NegativeTestMonkeys[i]];
            }

            return monkeys;
        }

        private Func<int, int> ParseOperation(string operation)
        {
            var args = operation.Split(" ");

            if (args[4] == "old")
            {
                return args[3] == "+"
                    ? (i => i + i)
                    : (i => i * i);
            }
            else
            {
                var parsedArg = int.Parse(args[4]);
                return args[3] == "+"
                    ? (i => i + parsedArg)
                    : (i => i * parsedArg);
            }
        }
    }

    public class Monkey
    {
        public int NumberOfInspections { get; private set; } = 0;
        public Monkey? PositiveTestMonkey { get; set; }
        public Monkey? NegativeTestMonkey { get; set; }
        public Queue<int> Items { get; }

        private Func<int, int> operation;
        private Func<int, bool> test;

        public Monkey(IEnumerable<int> startingItems, Func<int, int> operation, Func<int, bool> test)
        {
            this.Items = new Queue<int>(startingItems);
            this.operation = operation;
            this.test = test;
        }

        public void PerformRound()
        {
            while(Items.Count > 0)
            {
                int item = Items.Dequeue();
                item = operation(item);
                item /= 3;
                NumberOfInspections++;
                (test(item) ? PositiveTestMonkey : NegativeTestMonkey)?.Items.Enqueue(item);
            }
        }
    }
}
