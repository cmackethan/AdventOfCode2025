using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day1 : ISolution
{
    private const int _dialSize = 100;

    private readonly string[] _input = InputReader.ReadAsStringArray("Day1/Input.txt");

    private int _position = 50;
    private int _password = 0;

    public void Part1()
    {
        foreach (var (direction, distance) in _input.Select(x => (x[0], int.Parse(x[1..]))))
        {
            Console.WriteLine($"Input: {direction}{distance}");

            if (direction == 'L')
            {
                _position = (_position - distance) % _dialSize;

                if (_position < 0) _position += _dialSize;
                
                if (_position == 0) _password++;
            }
            else if (direction == 'R')
            {
                _position = (_position + distance) % _dialSize;
                
                if (_position == 0) _password++;
            }
            else
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"Position: {_position}");
            Console.WriteLine();
        }

        Console.WriteLine($"Password: {_password}");
    }

    public void Part2()
    {
        foreach (var (direction, distance) in _input.Select(x => (x[0], int.Parse(x[1..]))))
        {
            Console.WriteLine($"Input: {direction}{distance}");

            var rotations = 0;

            if (direction == 'L')
            {
                var positionWasZero = _position == 0;

                (rotations, _position) = Math.DivRem(_position - distance, _dialSize);

                rotations = Math.Abs(rotations);

                if (_position < 0)
                {
                    _position += _dialSize;

                    if (!positionWasZero && _position != 0) rotations++;
                }

                if (_position == 0) rotations++;

                _password += rotations;
            }
            else if (direction == 'R')
            {
                (rotations, _position) = Math.DivRem(_position + distance, _dialSize);

                _password += rotations;
            }
            else
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"Rotations: {rotations}");
            Console.WriteLine($"Position: {_position}");
            Console.WriteLine();
        }

        Console.WriteLine($"Password: {_password}");
    }
}
