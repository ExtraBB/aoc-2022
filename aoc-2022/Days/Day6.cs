using System.IO;

namespace aoc_2022.Days
{
    public class Day6 : IDay
    {
        public string Part1(string filePath, bool debug = false)
        {
            return FindStartMarker(filePath, 4).ToString();
        }

        public string Part2(string filePath, bool debug = false)
        {
            return FindStartMarker(filePath, 14).ToString();
        }

        private int FindStartMarker(string filePath, int size)
        {
            Queue<char> buffer = new Queue<char>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (i >= size)
                    {
                        buffer.Dequeue();
                    }

                    buffer.Enqueue((char)reader.Read());
                    if (buffer.Distinct().Count() == size)
                    {
                        return i + 1;
                    }
                }
            }

            return 0;
        }
    }
}
