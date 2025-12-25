using System;
using System.Collections.Generic;
using System.Text;

namespace aoc2025
{
    internal class _03
    {
        public static long start(string file)
        {
            Func<string, Tuple<char, int>> getBiggestChar = str =>
            {
                char biggestNr = '0';
                int positionOfBiggestNr = str.Length;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (biggestNr <= str[i])
                    {
                        biggestNr = str[i];
                        positionOfBiggestNr = i;
                    }
                }

                return new Tuple<char, int>(biggestNr, positionOfBiggestNr);
            };

            return File.ReadAllLines(@"data\03\" + file).Select(line =>
            {
                var biggest = getBiggestChar(line.Substring(0, line.Length - 1));
                var secondBiggest = getBiggestChar(line.Substring(biggest.Item2 + 1));
                return int.Parse(biggest.Item1.ToString() + secondBiggest.Item1);
            }).Sum();
        }
    }
}
