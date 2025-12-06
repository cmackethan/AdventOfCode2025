using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day4 : ISolution
{
    private const char _paper = '@';

    private readonly char[][] _grid = [.. InputReader.ReadAsStringArray("Day4/Input.txt").Select(x => x.ToCharArray())];

    private int _total = 0;

    public void Part1()
    {
        var n = _grid.Length;   // Assume NxN grid

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (_grid[i][j] == _paper && PositionIsAccessible(i, j, n))
                {
                    _total++;
                }
            }
        }

        Console.WriteLine($"Total: {_total}");
    }

    public void Part2()
    {
        var n = _grid.Length;   // Assume NxN grid

        var grid = _grid;

        var finished = false;
        while (!finished)
        {
            var newGrid = new char[n][];

            var currentTotal = 0;
            for (var i = 0; i < n; i++)
            {
                newGrid[i] = new char[n];

                for (var j = 0; j < n; j++)
                {
                    if (grid[i][j] == _paper && PositionIsAccessible(i, j, n, grid))
                    {
                        newGrid[i][j] = '.';
                        currentTotal++;
                    }
                    else
                    {
                        newGrid[i][j] = grid[i][j];
                    }
                }
            }

            grid = newGrid;
            _total += currentTotal;

            finished = currentTotal == 0;

            Console.WriteLine($"Current Total: {currentTotal}");
        }

        Console.WriteLine();
        Console.WriteLine($"Total: {_total}");
    }

    private bool PositionIsAccessible(int rowPos, int colPos, int n, char[][] grid = null)
    {
        bool IsStartingPosition(int i, int j) => i == rowPos && j == colPos;
        bool IsOutOfBounds(int i, int j) => i < 0 || i >= n || j < 0 || j >= n;

        grid ??= _grid;

        var sum = 0;
        for (var i = rowPos - 1; i <= rowPos + 1; i++)
        {
            for (var j = colPos - 1; j <= colPos + 1; j++)
            {
                if (IsStartingPosition(i, j) || IsOutOfBounds(i, j))
                {
                    continue;
                }

                if (grid[i][j] == _paper)
                {
                    sum++;
                }
            }
        }

        return sum < 4;
    }
}
