using System.Text.Json.Nodes;

namespace aoc_2022.Days;

public class Day13 : IDay
{
    public string Part1(string filePath)
    {
        var nodes = ParsePackets(filePath);
        var comparer = new PacketComparer();
        int result = 0;

        for (int i = 0; i < nodes.Count; i += 2)
        {
            if (comparer.Compare(nodes[i], nodes[i + 1]) == -1)
            {
                result += (i / 2) + 1;
            }
        }

        return result.ToString();
    }

    public string Part2(string filePath)
    {
        var comparer = new PacketComparer();
        var nodes = ParsePackets(filePath);

        var extraPackets = new[] { new JsonArray(new JsonArray(6)), new JsonArray(new JsonArray(2)) };
        nodes.AddRange(extraPackets);
        nodes = nodes.OrderBy(n => n, comparer).ToList();

        return ((nodes.IndexOf(extraPackets[0]) + 1) * (nodes.IndexOf(extraPackets[1]) + 1)).ToString();
    }

    private List<JsonNode> ParsePackets(string filePath)
    {
        var text = File.ReadAllText(filePath);
        var pairs = text.Split("\n\n");

        List<JsonNode> nodes = new List<JsonNode>();
        foreach (string pair in pairs)
        {
            var lines = pair.Split("\n");
            nodes.Add(JsonNode.Parse(lines[0]));
            nodes.Add(JsonNode.Parse(lines[1]));
        }

        return nodes;
    }
}

public class PacketComparer : IComparer<JsonNode>
{
    public int Compare(JsonNode left, JsonNode right)
    {
        if (left is JsonValue && right is JsonValue)
        {
            return Math.Sign(left.GetValue<int>() - right.GetValue<int>());
        }
        else if (left is JsonArray && right is JsonValue)
        {
            return Compare(left, new JsonArray(right.GetValue<int>()));
        }
        else if (left is JsonValue && right is JsonArray)
        {
            return Compare(new JsonArray(left.GetValue<int>()), right);
        }
        else
        {
            var leftArray = left.AsArray();
            var rightArray = right.AsArray();

            for (int i = 0; i < Math.Min(leftArray.Count, rightArray.Count); i++)
            {
                int comparison = Compare(leftArray[i], rightArray[i]);
                if (comparison != 0)
                {
                    return comparison;
                }
            }
            return Math.Sign(leftArray.Count - rightArray.Count);
        }
    }
}