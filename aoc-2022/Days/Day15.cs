using System.Text.RegularExpressions;

namespace aoc_2022.Days;

public class Day15 : IDay
{
    private int target = 10;
    private int maxBounds = 20;

    public void SetTarget(int target)
    {
        this.target = target;
    }

    public void SetMaxBounds(int maxBounds)
    {
        this.maxBounds = maxBounds;
    }

    public string Part1(string filePath)
    {
        var sensors = ParseSensors(filePath);

        HashSet<int> result = new HashSet<int>();
        HashSet<int> beaconsOnTarget = new HashSet<int>();

        foreach (var sensor in sensors)
        {
            if (sensor.beaconY == target)
            {
                beaconsOnTarget.Add(sensor.beaconX);
            }

            for (int x = sensor.sensorX - sensor.beaconDistance; x < sensor.sensorX + sensor.beaconDistance; x++)
            {
                if (Manhattan(sensor.sensorX, sensor.sensorY, x, target) <= sensor.beaconDistance)
                {
                    result.Add(x);
                }
            }
        }

        foreach (var beacon in beaconsOnTarget)
        {
            result.Remove(beacon);
        }

        return result.Count.ToString();
    }

    public string Part2(string filePath)
    {
        var sensors = ParseSensors(filePath);

        // Add all edges
        HashSet<(int x, int y)> edges = new HashSet<(int, int)>();
        foreach (var sensor in sensors)
        {
            int yOffset = 0;
            for (int x = Math.Max(0, sensor.sensorX - sensor.beaconDistance - 1); x <= Math.Min(sensor.sensorX + sensor.beaconDistance + 1, maxBounds); x++)
            {
                edges.Add((x, Math.Min(sensor.sensorY + yOffset, maxBounds)));
                edges.Add((x, Math.Max(0, sensor.sensorY - yOffset)));
                yOffset++;
            }
        }

        // Remove edges within distance of another sensor
        foreach (var edge in edges.ToList())
        {
            if (sensors.Any(s => Manhattan(edge.x, edge.y, s.sensorX, s.sensorY) <= s.beaconDistance))
            {
                edges.Remove(edge);
            }
        }

        return (4000000L * edges.First().x + edges.First().y).ToString();
    }

    private int Manhattan(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
    }

    private List<(int sensorX, int sensorY, int beaconX, int beaconY, int beaconDistance)> ParseSensors(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        List<(int sensorX, int sensorY, int beaconX, int beaconY, int beaconDistance)> sensors = new List<(int, int, int, int, int)>();
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"=-?\d+");
            var sensorX = int.Parse(matches[0].Value.Substring(1));
            var sensorY = int.Parse(matches[1].Value.Substring(1));
            var beaconX = int.Parse(matches[2].Value.Substring(1));
            var beaconY = int.Parse(matches[3].Value.Substring(1));

            int dist = Manhattan(sensorX, sensorY, beaconX, beaconY);
            sensors.Add((sensorX, sensorY, beaconX, beaconY, dist));
        }

        return sensors;
    }
}