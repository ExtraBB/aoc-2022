using System.Text.RegularExpressions;

namespace aoc_2022.Days
{
    public class Day11 : IDay
    {
        public string Part1(string filePath, bool debug = false)
        {
            return Run(filePath, true);
        }

        public string Part2(string filePath, bool debug = false)
        {
            return Run(filePath, false);
        }

        private string Run(string filePath, bool part1)
        {
            List<Monkey> monkeys = ParseMonkeys(filePath, part1);

            for (long i = 0; i < (part1 ? 20 : 10000); i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.PerformRound();
                }
            }

            var ordered = monkeys.OrderByDescending(m => m.NumberOfInspections).ToList();

            return (ordered[0].NumberOfInspections * ordered[1].NumberOfInspections).ToString();
        }

        private List<Monkey> ParseMonkeys(string filePath, bool part1)
        {
            List<Monkey> monkeys = new List<Monkey>();
            Dictionary<int, int> PositiveTestMonkeys = new Dictionary<int, int>();
            Dictionary<int, int> NegativeTestMonkeys = new Dictionary<int, int>();

            int counter = 0;
            foreach (var monkey in File.ReadAllText(filePath).Split(Environment.NewLine + Environment.NewLine))
            {
                var lines = monkey.Split(Environment.NewLine);
                var items = lines[1].Split(":")[1].Split(",").Select(x => long.Parse(x.Trim()));
                var divisibleBy = long.Parse(lines[3].Split(" ").Last());
                var operation = ParseOperation(lines[2].Split(":")[1].Trim());

                PositiveTestMonkeys[counter] = int.Parse(lines[4].Split(" ").Last());
                NegativeTestMonkeys[counter] = int.Parse(lines[5].Split(" ").Last());

                monkeys.Add(new Monkey(items, operation, divisibleBy, part1));
                counter++;
            }

            long combinedMod = monkeys.Aggregate(1L, (i, j) => i * j.DivisibleBy);
            for (int i = 0; i < counter; i++)
            {
                monkeys[i].PositiveTestMonkey = monkeys[PositiveTestMonkeys[i]];
                monkeys[i].NegativeTestMonkey = monkeys[NegativeTestMonkeys[i]];
                monkeys[i].CombinedMod = combinedMod;
            }

            return monkeys;
        }

        private Func<long, long> ParseOperation(string operation)
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
                var parsedArg = long.Parse(args[4]);
                return args[3] == "+"
                    ? (i => i + parsedArg)
                    : (i => i * parsedArg);
            }
        }
    }

    public class Monkey
    {
        public long NumberOfInspections { get; private set; } = 0;
        public Monkey? PositiveTestMonkey { get; set; }
        public Monkey? NegativeTestMonkey { get; set; }
        public Queue<long> Items { get; }
        public long CombinedMod { get; set; }
        public long DivisibleBy { get; private set; }

        private Func<long, long> operation;
        private bool part1;

        public Monkey(IEnumerable<long> startingItems, Func<long, long> operation, long divisibleBy, bool part1)
        {
            this.Items = new Queue<long>(startingItems);
            this.operation = operation;
            this.DivisibleBy = divisibleBy;
            this.part1 = part1;
        }

        public void PerformRound()
        {
            while (Items.Count > 0)
            {
                long item = Items.Dequeue();

                item = part1
                    ? operation(item) / 3
                    : operation(item) % CombinedMod;

                NumberOfInspections++;
                (item % DivisibleBy == 0 ? PositiveTestMonkey : NegativeTestMonkey)?.Items.Enqueue(item);
            }
        }
    }
}
