using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using Range = (long min, long max);

namespace aoc2025
{
    internal class _05
    {
        public static long start(string file)
        {
            var lines = File.ReadAllLines(@"data\05\" + file);
            var ranges = lines.Where(line => line.Contains("-")).Select(line =>
            {
                long[] numbers = line.Split('-').Select(item => long.Parse(item)).ToArray();
                return (a: numbers[0], b: numbers[1]);
            });
            var ids = lines.Where(line => line.Length > 0 && !line.Contains("-")).Select(item => long.Parse(item));

            return ids.Where(id => ranges.Any(range => (range.a <= id) && (id <= range.b))).ToArray().Count();
        }

        public static long start2(string file)
        {
            var lines = File.ReadAllLines(@"data\05\" + file).Where(line => line.Contains("-"));
            List<Range> ranges = new List<Range>();

            int findMatchingRange(List<Range> ranges, Range toFind)
            {
                bool isInRange(long num, long min, long max)
                {
                    return (min <= num) && (max >= num);
                }

                return ranges.FindIndex(range =>
                {
                    bool startIsIncluded = isInRange(toFind.min, range.min, range.max);
                    bool endIsIncluded = isInRange(toFind.max, range.min, range.max);
                    bool rangeStartIsIncluded = isInRange(range.min, toFind.min, toFind.max);
                    bool rangeEndIsIncluded = isInRange(range.max, toFind.min, toFind.max);

                    return startIsIncluded || endIsIncluded || rangeStartIsIncluded || rangeEndIsIncluded;
                });
            }

            void addOrAdjustRanges(List<Range> ranges, Range toFind)
            {
                var index = findMatchingRange(ranges, toFind);
                if (index == -1)
                {
                    ranges.Add(toFind);
                }
                else
                {
                    var found = ranges[index];
                    ranges[index] = (
                        min: toFind.min < found.min ? toFind.min : found.min,
                        max: toFind.max > found.max ? toFind.max : found.max
                    );
                }
            }

            foreach (var line in lines)
            {
                long[] minMaX = line.Split('-').Select(item => long.Parse(item)).ToArray();
                addOrAdjustRanges(ranges, (min: minMaX[0], max: minMaX[1]));
            }

            var oldRangesCount = ranges.Count;
            do
            {
                oldRangesCount = ranges.Count;
                var newRanges = new List<Range>();

                for (int i = 0; i < ranges.Count; i++)
                {
                    addOrAdjustRanges(newRanges, ranges[i]);
                }

                ranges = newRanges;
            } while(oldRangesCount != ranges.Count);

            return ranges.Select(range => range.max + 1 - range.min).Sum();
        }
    }
}
