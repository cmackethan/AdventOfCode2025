using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day7 : ISolution
{
    private readonly char[][] _diagram = [.. InputReader.ReadAsStringArray("Day7/Input.txt").Select(x => x.ToCharArray())];

    public void Part1()
    {
        var totalSplits = 0;

        HashSet<int> currentBeams = [_diagram[0].IndexOf('S')];
        foreach (var line in _diagram[1..])
        {
            var newBeams = new HashSet<int>();
            foreach (var beam in currentBeams)
            {
                if (line[beam] == '^')
                {
                    newBeams.Add(beam + 1);
                    newBeams.Add(beam - 1);

                    totalSplits++;
                }
                else
                {
                    newBeams.Add(beam);
                }
            }

            currentBeams = newBeams;
        }

        Console.WriteLine($"Total Splits: {totalSplits}");
    }

    public void Part2()
    {
        static void AddOrUpdate(Dictionary<int, long> map, int currentBeam, long currentNumTimelines)
        {
            if (map.TryGetValue(currentBeam, out var newNumTimelines))
            {
                map[currentBeam] = newNumTimelines + currentNumTimelines;
            }
            else
            {
                map.Add(currentBeam, currentNumTimelines);
            }
        }

        var currentMap = new Dictionary<int, long>() { { _diagram[0].IndexOf('S'), 1 } };
        foreach (var line in _diagram[1..])
        {
            var newMap = new Dictionary<int, long>();
            foreach (var entry in currentMap)
            {
                if (line[entry.Key] == '^')
                {
                    AddOrUpdate(newMap, entry.Key + 1, entry.Value);
                    AddOrUpdate(newMap, entry.Key - 1, entry.Value);
                }
                else
                {
                    AddOrUpdate(newMap, entry.Key, entry.Value);
                }
            }

            currentMap = newMap;
        }

        Console.WriteLine($"Total Timelines: {currentMap.Values.Sum()}");
    }
}
