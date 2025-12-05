using System.Reflection.Emit;
using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day1 : ISolution
{
    private const int _dialSize = 100;

    public void Part1()
    {
        var input = InputReader.ReadAsStringArray("/Users/cmackethan/dev/aoc2025/AdventOfCode2025/Input/Day1/Input.txt");

        var (position, password) = (50, 0);

        foreach (var (direction, distance) in input.Select(x => (x[0], int.Parse(x[1..]))))
        {
            Console.WriteLine($"Input: {direction}{distance}");

            if (direction == 'L')
            {
                position = (position - distance) % _dialSize;

                if (position < 0) position += _dialSize;
                
                if (position == 0) password++;
            }
            else if (direction == 'R')
            {
                position = (position + distance) % _dialSize;
                
                if (position == 0) password++;
            }
            else
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"Position: {position}");
            Console.WriteLine();
        }

        Console.WriteLine($"Password: {password}");
    }

    public void Part2()
    {
        var input = InputReader.ReadAsStringArray("/Users/cmackethan/dev/aoc2025/AdventOfCode2025/Input/Day1/Input.txt");

        var (position, password) = (50, 0);

        foreach (var (direction, distance) in input.Select(x => (x[0], int.Parse(x[1..]))))
        {
            Console.WriteLine($"Input: {direction}{distance}");

            var rotations = 0;

            if (direction == 'L')
            {
                var positionWasZero = position == 0;

                (rotations, position) = Math.DivRem(position - distance, _dialSize);

                rotations = Math.Abs(rotations);

                if (position < 0)
                {
                    position += _dialSize;

                    if (!positionWasZero && position != 0) rotations++;
                }

                if (position == 0) rotations++;

                password += rotations;
            }
            else if (direction == 'R')
            {
                (rotations, position) = Math.DivRem(position + distance, _dialSize);

                password += rotations;
            }
            else
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"Rotations: {rotations}");
            Console.WriteLine($"Position: {position}");
            Console.WriteLine();
        }

        Console.WriteLine($"Password: {password}");
    }
}
