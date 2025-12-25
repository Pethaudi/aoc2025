using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace aoc2025
{
    internal class _07
    {
        public static int start(string file)
        {
            var field = File.ReadAllLines(@"data\07\" + file);

            int nextStep(List<int> prevStep, int lineIdx, int splitCounter, bool print = false)
            {
                if (lineIdx ==  field.Length)
                {
                    return splitCounter;
                }

                var line = field[lineIdx];
                var steps = new SortedSet<int>();

                prevStep.ForEach(idx =>
                {
                    if (line[idx] == '.')
                    {
                        steps.Add(idx);
                    }
                    else
                    {
                        splitCounter++;
                        if (idx > 0)
                        {
                            steps.Add(idx - 1);
                        }

                        if (idx < line.Length - 1)
                        {
                            steps.Add(idx + 1);
                        }
                    }
                });

                if (print)
                {
                    Console.WriteLine(line.Select((c, idx) => steps.Contains(idx) ? '|' : c).Aggregate("", (sum, c) => sum + c));
                }

                return nextStep(steps.ToList(), lineIdx + 1, splitCounter, print);
            }

            var start = 0;
            for (int i = 0; i < field[0].Length; i++)
            {
                if (field[0][i] == 'S')
                {
                    start = i;
                    break;
                }
            }

            return nextStep(new List<int>{ start }, 1, 0, false);
        }
    }
}
