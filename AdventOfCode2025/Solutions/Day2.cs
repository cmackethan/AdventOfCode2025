using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day2 : ISolution
{
    private readonly string[] _input = InputReader.ReadAsString("Day2/Input.txt").Split(',');

    private long _sum = 0;

    public void Part1()
    {
        foreach (var range in _input)
        {
            Console.WriteLine($"Range: {range}");

            var rangeIDs = range.Split('-')
                .Select(x => long.Parse(x))
                .ToArray();

            for (var i = rangeIDs[0]; i <= rangeIDs[1]; i++)
            {
                var id = i.ToString();

                if (id.Length % 2 != 0) continue;

                var partition = id.Length / 2;

                if (id[..partition] == id[partition..])
                {
                    _sum += i;

                    Console.WriteLine($"Invalid ID: {id}");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Sum: {_sum}");
    }

    public void Part2()
    {
        foreach (var range in _input)
        {
            Console.WriteLine($"Range: {range}");

            var rangeIDs = range.Split('-')
                .Select(x => long.Parse(x))
                .ToArray();

            for (var i = rangeIDs[0]; i <= rangeIDs[1]; i++)
            {
                var id = i.ToString();

                for (var j = 1; j <= id.Length / 2; j++)
                {
                    var chunks = id.Chunk(j).Select(x => new string(x));

                    var firstChunk = chunks.First();

                    if (chunks.All(x => x == firstChunk))
                    {
                        _sum += i;

                        Console.WriteLine($"Invalid ID: {id}");

                        break;
                    }
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Sum: {_sum}");
    }
}
