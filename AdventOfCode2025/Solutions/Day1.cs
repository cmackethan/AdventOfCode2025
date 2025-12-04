using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day1 : ISolution
{
    public void Part1()
    {
        var input = InputReader.ReadAsStringArray("/Users/cmackethan/dev/aoc2025/AdventOfCode2025/Input/Day1/Part1.txt");

        var (position, password) = (50, 0);

        foreach (var (direction, distance) in input.Select(x => (x[0], int.Parse(x[1..]))))
        {
            if (direction == 'L')
            {
                position -= distance % 100;

                if (position < 0) position += 100;
                
                if (position == 0) password++;
            }
            else
            {
                position += distance % 100;

                if (position > 99) position -= 100;
                
                if (position == 0) password++;
            }

            Console.WriteLine($"Position: {position}");
        }

        Console.WriteLine($"Password: {password}");
    }

    public void Part2()
    {
        throw new NotImplementedException();
    }
}
