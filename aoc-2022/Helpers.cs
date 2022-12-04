using System.Text.RegularExpressions;

namespace aoc_2022
{
    public static class Helpers
    {
        public static string[] ParseGroupsFromString(Regex regex, string input)
        {
            return regex.Match(input)
                .Groups.Values.Skip(1)
                .Select(g => g.Value)
                .ToArray();
        }

        public static T[] ParseGroupsFromStringAndConvert<T>(Regex regex, string input, Func<string, T> conversionFunc)
        {
            return regex.Match(input)
                .Groups.Values.Skip(1)
                .Select(g => conversionFunc(g.Value))
                .ToArray();
        }
    }
}
