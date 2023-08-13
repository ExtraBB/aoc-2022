using System.Text.Json.Nodes;

namespace aoc_2022.Days;

public class Day13 : IDay
{
    public string Part1(string filePath)
    {
        var text = File.ReadAllText(filePath);
        var pairs = text.Split("\n\n");
        int result = 0, index = 1;
        foreach (string pair in pairs)
        {
            var lines = pair.Split("\n");
            var left = JsonNode.Parse(lines[0]);
            var right = JsonNode.Parse(lines[1]);

            if (CompareOrder(left, right) == -1)
            {
                Console.WriteLine(index);
                result += index;
            }

            index++;
        }

        return result.ToString();
    }

    public string Part2(string filePath)
    {
        throw new NotImplementedException();
    }

    private int CompareOrder(JsonNode left, JsonNode right)
    {
        if (left is JsonValue && right is JsonValue)
        {
            return Math.Sign(left.GetValue<int>() - right.GetValue<int>());
        }
        else if (left is JsonArray && right is JsonValue)
        {
            return CompareOrder(left, new JsonArray(right.GetValue<int>()));
        }
        else if (left is JsonValue && right is JsonArray)
        {
            return CompareOrder(new JsonArray(left.GetValue<int>()), right);
        }
        else
        {
            var leftArray = left.AsArray();
            var rightArray = right.AsArray();

            for (int i = 0; i < Math.Min(leftArray.Count, rightArray.Count); i++)
            {
                int comparison = CompareOrder(leftArray[i], rightArray[i]);
                if (comparison != 0)
                {
                    return comparison;
                }
            }
            return Math.Sign(leftArray.Count - rightArray.Count);
        }
    }
}