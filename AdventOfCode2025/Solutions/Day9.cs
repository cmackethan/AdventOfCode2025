using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day9 : ISolution
{
    private readonly string[] _input = InputReader.ReadAsStringArray("Day9/Input.txt");

    public void Part1()
    {
        static long GetArea((int x, int y) tile1, (int x, int y) tile2)
        {
            long length = Math.Abs(tile1.x - tile2.x + 1);
            long width = Math.Abs(tile1.y - tile2.y + 1);

            return length * width;
        }

        var tiles = _input
            .Select(x => x.Split(',').Select(x => int.Parse(x)).ToArray())
            .Select(x => (x: x[0], y: x[1]));

        var maxArea = tiles
            .SelectMany((_, i) => tiles.Skip(i + 1), (tile1, tile2) => (tile1, tile2))
            .Select(x => GetArea(x.tile1, x.tile2))
            .Max();

        Console.WriteLine($"Max Area: {maxArea}");
    }

    public void Part2()
    {
        throw new NotImplementedException();
    }
}
