using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc2025
{
    internal class _06
    {
        public static long start(string file)
        {
            IEnumerable<string> splitLine(string line)
            {
                return line.Split(null)
                    .Where(line => line.Length > 0);
            }

            var lines = File.ReadAllLines(@"data\06\" + file);
            var calcs = splitLine(lines.Last())
                .Select(op => {
                    return (op: op[0], numbers: new List<long>());
                })
                .ToList();
            lines = lines.SkipLast(1).ToArray();
            foreach (var item in lines)
            {
                var numbers = splitLine(item)
                    .Select(num => long.Parse(num))
                    .ToList();

                for (var i = 0; i < numbers.Count; i++)
                {
                    calcs[i].numbers.Add(numbers[i]);
                }
            }

            return calcs.Sum(calc =>
            {
                long doOp(long a, long b)
                {
                    return calc.op == '+' ? a + b : a * b;
                }

                return calc.numbers.Skip(1).Aggregate(calc.numbers[0], (res, item) => doOp(res, item));
            });
        }

        public static long start2(string file)
        {
            IEnumerable<string> splitLine(string line)
            {
                return line.Split(null)
                    .Where(line => line.Length > 0);
            }

            var lines = File.ReadAllLines(@"data\06\" + file);
            var calcs = splitLine(lines.Last())
                .Select(op => {
                    return (op: op[0], numbers: new List<long>());
                })
                .ToList();
            lines = lines.SkipLast(1).ToArray();

            Enumerable.Range(0, lines[0].Length)
                .Select(i => lines.Aggregate("", (sum, line) => sum + line[i]).ToString())
                .Aggregate(0, (blockIndex, line) =>
                {
                    try
                    {
                        calcs[blockIndex].numbers.Add(long.Parse(line));
                    }
                    catch (FormatException)
                    {
                        blockIndex++;
                    }
                    return blockIndex;
                });

            return calcs.Sum(calc =>
            {
                long doOp(long a, long b)
                {
                    return calc.op == '+' ? a + b : a * b;
                }

                return calc.numbers.Skip(1).Aggregate(calc.numbers[0], (res, item) => doOp(res, item));
            });
        }
    }
}
