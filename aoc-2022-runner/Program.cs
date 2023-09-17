using aoc_2022.Days;
using System.Linq;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        int day = int.Parse(args[0]);
        int part = int.Parse(args[1]);
        string folder = args[2];

        Type t = Type.GetType($"aoc_2022.Days.Day{day},aoc-2022");
        IDay dayObj = (IDay)Activator.CreateInstance(t);

        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"./{folder}/{day}.txt");
        Console.WriteLine("Result: " + (part == 1 ? dayObj.Part1(path, true) : dayObj.Part2(path, true)));
    }
}