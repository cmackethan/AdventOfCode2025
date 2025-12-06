using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day3 : ISolution
{
    private readonly string[] _input = InputReader.ReadAsStringArray("Day3/Input.txt");

    public void Part1()
    {
        int totalMaxJoltage = 0;

        foreach (var bank in _input)
        {
            Console.WriteLine($"Bank: {bank}");

            var batteries = bank.Select(x => x - '0').ToArray();

            var firstBattery = batteries[..^1].Max();
            var firstBatteryIndex = batteries.IndexOf(firstBattery);

            var secondBattery = batteries[(firstBatteryIndex + 1)..].Max();

            var maxJoltage = $"{firstBattery}{secondBattery}";

            totalMaxJoltage += int.Parse(maxJoltage);

            Console.WriteLine($"Max Joltage: {maxJoltage}");
            Console.WriteLine();
        }

        Console.WriteLine($"Total Max Joltage: {totalMaxJoltage}");
    }

    public void Part2()
    {
        const int numBatteries = 12;

        long totalMaxJoltage = 0;

        foreach (var bank in _input)
        {
            Console.WriteLine($"Bank: {bank}");

            var batteries = bank.Select(x => x - '0').ToArray();

            var maxJoltage = string.Empty;
            var startIndex = 0;
            
            for (var i = 1; i <= numBatteries; i++)
            {
                var maxBattery = 0;

                for (var j = startIndex; j < batteries.Length - (numBatteries - i); j++)
                {
                    var currentBattery = batteries[j];

                    if (currentBattery > maxBattery)
                    {
                        maxBattery = currentBattery;
                        startIndex = j + 1;

                        if (currentBattery == 9) break;
                    }
                }

                maxJoltage += maxBattery.ToString();
            }

            totalMaxJoltage += long.Parse(maxJoltage);

            Console.WriteLine($"Max Joltage: {maxJoltage}");
            Console.WriteLine();
        }

        Console.WriteLine($"Total Max Joltage: {totalMaxJoltage}");
    }
}
