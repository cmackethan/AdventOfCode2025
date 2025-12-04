using System.Reflection;
using AdventOfCode2025.Solutions.Interfaces;

namespace AdventOfCode2025;

internal class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            while (true)
            {
                Console.WriteLine("Enter the day and part of the puzzle to solve, e.g., 1.1 for day 1, part 1.");
                
                Run(Console.ReadLine());
            }
        }
        else if (args.Length == 1)
        {
            Run(args[0]);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private static void Run(string input)
    {
        var splitInput = input.Split('.');

        var (day, part) = (splitInput[0], splitInput[1]);

        var solutionType = Assembly.GetExecutingAssembly().GetType($"AdventOfCode2025.Solutions.Day{day}");

        var solution = Activator.CreateInstance(solutionType) as ISolution;

        if (part == "1")
        {
            solution.Part1();
        }
        else if (part == "2")
        {
            solution.Part2();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
