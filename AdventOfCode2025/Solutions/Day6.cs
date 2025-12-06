using System.Diagnostics;
using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day6 : ISolution
{
    private readonly string[] _input = InputReader.ReadAsStringArray("Day6/Input.txt");

    public void Part1()
    {
        var stringSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
        var lines = _input.Select(x => x.Split((char[])null, stringSplitOptions)).ToArray();

        long total = 0;
        for (int i = 0; i < lines[0].Length; i++)
        {
            var numbers = new List<int>();
            for (int j = 0; j < lines.Length - 1; j++)
            {
                numbers.Add(int.Parse(lines[j][i]));
            }

            var operation = lines[^1][i][0];

            var result = ComputeResult(numbers, operation);

            total += result;

            Console.WriteLine($"Problem: {string.Join($" {operation} ", numbers)}");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }

        Console.WriteLine($"Total: {total}");
    }

    public void Part2()
    {
        var lines = _input.Select(x => x.ToCharArray()).ToArray();

        long total = 0;
        
        var numbers = new List<int>();

        for (int i = lines[0].Length - 1; i >= 0; i--)
        {
            if (lines.All(x => char.IsWhiteSpace(x[i]))) continue;

            var numberStr = string.Empty;
            for (int j = 0; j < lines.Length - 1; j++)
            {
                var digit = lines[j][i];
                if (!char.IsWhiteSpace(digit))
                {
                    numberStr += digit;
                }
            }

            numbers.Add(int.Parse(numberStr));

            var operation = lines[^1][i];
            if (!char.IsWhiteSpace(operation))
            {
                var result = ComputeResult(numbers, operation);

                total += result;
                
                Console.WriteLine($"Problem: {string.Join($" {operation} ", numbers)}");
                Console.WriteLine($"Result: {result}");
                Console.WriteLine();

                numbers.Clear();
            }
        }

        Console.WriteLine($"Total: {total}");
    }

    private static long ComputeResult(List<int> numbers, char operation) => operation switch
    {
        '+' => numbers.Sum(),
        '*' => numbers.Aggregate((long)1, (acc, x) => acc *= x),
        _ => throw new UnreachableException()
    };
}
