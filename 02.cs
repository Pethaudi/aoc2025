using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc2025
{
    internal class _02
    {
        public static long start(string file)
        {
            return File.ReadAllLines(@"data\02\" + file)[0].Split(',').SelectMany(range =>
            {
                string[] parts = range.Split('-');
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                List<long> res = new List<long>();
                for (long i = start; i < end + 1; i++)
                {
                    string iString = i.ToString();
                    if (iString.Length % 2 == 0 && iString.Substring(0, iString.Length / 2).Equals(iString.Substring(iString.Length / 2)))
                    {
                        res.Add(i);
                    }
                }
                return res;
            }).Sum();
        }
    }
}
