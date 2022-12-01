namespace aoc_2022.Utils;

public static class FileUtils
{
    public static List<List<T>> ReadLineGroups<T>(string path, Func<string, T> conversionFunc)
    {
        var lines = File.ReadAllLines(path);
        
        List<List<T>> result = new List<List<T>>();

        List<T> currentGroup = new List<T>();
        foreach(var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) 
            {
                if (currentGroup.Count > 0) 
                {
                    result.Add(currentGroup);
                }
                currentGroup = new List<T>();
                continue;
            }
            currentGroup.Add(conversionFunc(line));
        }

        if (currentGroup.Count > 0) 
        {
            result.Add(currentGroup);
        }

        return result;
    }
}