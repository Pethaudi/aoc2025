using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Xml;

namespace aoc2025
{
    internal class _03_2
    {
        public static long start(string file)
        {
            return File.ReadAllLines(@"data\03\" + file).Select(line =>
            {
                var bestPositions = new SortedSet<int>();
                int currentBestIndex = 0;

                long getNumber(SortedSet<int> indizes, int additionalIndex)
                {
                    var newIndizies = new SortedSet<int>(indizes);
                    if (additionalIndex != -1)
                    {
                        newIndizies.Add(additionalIndex);
                    }
                    return long.Parse(newIndizies.Select(index => line[index]).Aggregate("", (sum, val) => sum + val));
                }

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (
                            !bestPositions.Contains(j) &&
                            (bestPositions.Count() == i + 1 || getNumber(bestPositions, currentBestIndex) < getNumber(bestPositions, j))
                        )
                        {
                            currentBestIndex = j;
                        }
                    }
                    bestPositions.Add(currentBestIndex);
                }

                return getNumber(bestPositions, -1);
            }).Sum();
        }
    }
}
