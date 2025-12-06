using AdventOfCode2025.Solutions.Interfaces;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Solutions;

internal class Day5 : ISolution
{
    private readonly string[] _input = InputReader.ReadAsStringArray("Day5/Input.txt");

    private class Range
    {
        public long Low { get; set; }
        public long High { get; set; }

        public bool IsSupersetOfOrEqualTo(Range other) => Low <= other.Low && High >= other.High;
        public bool IsSubsetOf(Range other) => Low > other.Low && High < other.High;
        public bool IsOverlappedByLowOf(Range other) => Low > other.Low && High >= other.High && Low <= other.High;
        public bool IsOverlappedByHighOf(Range other) => Low <= other.Low && High < other.High && High >= other.Low;
    }

    public void Part1()
    {
        var total = 0;
        var parsingRanges = true;
        var ranges = new List<Range>();

        foreach (var line in _input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                parsingRanges = false;
                continue;
            }

            if (parsingRanges)
            {
                var range = line.Split('-')
                    .Select(x => long.Parse(x))
                    .ToArray();

                ranges.Add(new()
                {
                    Low = range[0],
                    High = range[1]
                });
            }
            else
            {
                var id = long.Parse(line);

                if (ranges.Any(x => x.Low <= id && x.High >= id))
                {
                    total++;
                }
            }
        }

        Console.WriteLine($"Total: {total}");
    }

    public void Part2()
    {
        var ranges = new List<Range>();
        foreach (var line in _input)
        {
            if (string.IsNullOrWhiteSpace(line)) break;

            var range = line.Split('-')
                .Select(x => long.Parse(x))
                .ToArray();

            ranges.Add(new()
            {
                Low = range[0],
                High = range[1]
            });
        }

        var finished = false;
        while (!finished)
        {
            finished = true;

            var combinedRanges = new List<Range>();
            for (int i = 0; i < ranges.Count; i++)
            {
                var range = ranges[i];

                if (combinedRanges.Any(x => x.IsSupersetOfOrEqualTo(range)))
                {
                    finished = false;
                    continue;
                }

                var subset = combinedRanges.SingleOrDefault(x => x.IsSubsetOf(range));
                if (subset is not null)
                {
                    subset.Low = range.Low;
                    subset.High = range.High;

                    finished = false;
                    continue;
                }

                var overlappedByLow = combinedRanges.SingleOrDefault(x => x.IsOverlappedByLowOf(range));
                if (overlappedByLow is not null)
                {
                    overlappedByLow.Low = range.Low;
                    
                    finished = false;
                    continue;
                }

                var overlappedByHigh = combinedRanges.SingleOrDefault(x => x.IsOverlappedByHighOf(range));
                if (overlappedByHigh is not null)
                {
                    overlappedByHigh.High = range.High;

                    finished = false;
                    continue;
                }

                combinedRanges.Add(range);
            }

            ranges = combinedRanges;
        }

        long total = 0;
        foreach (var range in ranges)
        {
            total += range.High - range.Low + 1;
        }

        Console.WriteLine($"Total: {total}");
    }
}
