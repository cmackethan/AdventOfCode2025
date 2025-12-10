using System.Xml.Linq;
using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day8 : ISolution
{
    private readonly string[] _input = InputReader.ReadAsStringArray("Day8/Input.txt");

    private class Position
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public long GetDistance(Position otherPosition)
        {
            var deltaX = X - otherPosition.X;
            var deltaY = Y - otherPosition.Y;
            var deltaZ = Z - otherPosition.Z;

            return (deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ);
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                X == position.X &&
                Y == position.Y &&
                Z == position.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }

    public void Part1()
    {
        var positions = _input
            .Select(x => x.Split(',').Select(x => int.Parse(x)).ToArray())
            .Select(x => new Position() { X = x[0], Y = x[1], Z = x[2] })
            .ToArray();

        var combinations = positions
            .SelectMany((_, i) => positions.Skip(i + 1), (pos1, pos2) => (pos1, pos2))
            .OrderBy(x => x.pos1.GetDistance(x.pos2))
            .Take(1000);

        var circuits = new List<HashSet<Position>>();
        foreach (var (pos1, pos2) in combinations)
        {
            var pos1Circuit = circuits.SingleOrDefault(x => x.Contains(pos1));
            var pos2Circuit = circuits.SingleOrDefault(x => x.Contains(pos2));

            if (pos1Circuit is not null && pos2Circuit is not null)
            {
                if (pos1Circuit != pos2Circuit)
                {
                    pos1Circuit.UnionWith(pos2Circuit);
                    circuits.Remove(pos2Circuit);    
                }
            }
            else if (pos1Circuit is not null)
            {
                pos1Circuit.Add(pos2);
            }
            else if (pos2Circuit is not null)
            {
                pos2Circuit.Add(pos1);
            }
            else
            {
                circuits.Add([pos1, pos2]);
            }
        }

        var size = circuits
            .Select(x => x.Count)
            .OrderByDescending(x => x)
            .Take(3)
            .Aggregate((long)1, (acc, x) => acc *= x);

        Console.WriteLine($"Size: {size}");
    }

    public void Part2()
    {
        var positions = _input
            .Select(x => x.Split(',').Select(x => int.Parse(x)).ToArray())
            .Select(x => new Position() { X = x[0], Y = x[1], Z = x[2] })
            .ToArray();

        var combinations = positions
            .SelectMany((_, i) => positions.Skip(i + 1), (pos1, pos2) => (pos1, pos2))
            .OrderBy(x => x.pos1.GetDistance(x.pos2));

        var circuits = new List<HashSet<Position>>();
        foreach (var (pos1, pos2) in combinations)
        {
            var pos1Circuit = circuits.SingleOrDefault(x => x.Contains(pos1));
            var pos2Circuit = circuits.SingleOrDefault(x => x.Contains(pos2));

            if (pos1Circuit is not null && pos2Circuit is not null)
            {
                if (pos1Circuit != pos2Circuit)
                {
                    pos1Circuit.UnionWith(pos2Circuit);
                    circuits.Remove(pos2Circuit);    
                }
            }
            else if (pos1Circuit is not null)
            {
                pos1Circuit.Add(pos2);
            }
            else if (pos2Circuit is not null)
            {
                pos2Circuit.Add(pos1);
            }
            else
            {
                circuits.Add([pos1, pos2]);
            }

            if (circuits.Select(x => x.Count).Max() == positions.Length)
            {
                Console.WriteLine($"Coordinates {pos1.X * pos2.X}");
                break;
            }
        }
    }
}
