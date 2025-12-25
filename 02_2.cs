using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc2025
{
    internal class _02_2
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
                    foreach (var length in Enumerable.Range(1, iString.Length / 2))
                    {
                        if (iString.Length % length == 0 && Regex.Count(iString, iString.Substring(0, length)) == (iString.Length / length))
                        {
                            res.Add(i);
                            break;
                        }
                    }
                }

                return res;
            }).Sum();


        }
    }
}
