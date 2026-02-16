using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        /* public static int start2(string file)
        {

            var field = File.ReadAllLines(@"data\07\" + file);

            int nextStep(int prevCharIdx, int lineIdx, TimelineIsDone isDone, bool print = false)
            {
                if (lineIdx == field.Length)
                {
                    return 1;
                }

                if (field[lineIdx][prevCharIdx] == '^')
                {
                    int timelineCounter = 0; */

                    /* Task createTask(int newPrevCharIdx)
                    {
                        return new Task(() =>
                        {
                            timelineCounter += nextStep(prevCharIdx, lineIdx + 1, print);
                        });
                    }

                    var tasks = new List<Task>();
                    if (prevCharIdx != 0)
                    {
                        tasks.Add(createTask(prevCharIdx - 1));
                    }

                    if (prevCharIdx == field[lineIdx].Length - 1)
                    {
                        tasks.Add(createTask(prevCharIdx + 1));
                    }

                    await Task.WaitAll(tasks); */
                    /* return (prevCharIdx == 0 ? 0 : nextStep(prevCharIdx - 1, lineIdx + 1, print)) +
                        (prevCharIdx == field[lineIdx].Length - 1 ? 0 : nextStep(prevCharIdx + 1, lineIdx + 1, print));
                } else
                {
                    return nextStep(prevCharIdx, lineIdx + 1, print);
                }
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



            return nextStep(start, 1, false);

            // return timelineCounter;
        } */

        public static void start3(string file, TimelineIsDone isDone)
        {
            var field = File.ReadAllLines(@"data\07\" + file);
            var start = 0;
            for (int i = 0; i < field[0].Length; i++)
            {
                if (field[0][i] == 'S')
                {
                    start = i;
                    break;
                }
            }
            nextStep2(field, start, 1, isDone, true);
        }

        public delegate void TimelineIsDone(int counter);

        private static void nextStep2(string[] field, int prevCharIdx, int lineIdx, TimelineIsDone isDone, bool print = false)
        {
            if (lineIdx == field.Length - 1)
            {
                Console.WriteLine("done");
                isDone(1);
            }

            if (field[lineIdx][prevCharIdx] == '^')
            {
                var task = new Task(() =>
                {
                    if (prevCharIdx != 0)
                    {
                        nextStep2(field, prevCharIdx - 1, lineIdx + 1, isDone, print);
                    }

                    if (prevCharIdx == field[lineIdx].Length - 1)
                    {
                        nextStep2(field, prevCharIdx + 1, lineIdx + 1, (int c) => isDone(c + 1), print);
                    }
                });
                task.Start();
            }
            else
            {
                nextStep2(field, prevCharIdx, lineIdx + 1, isDone, print);
            }

            Console.WriteLine("Next Step 2 finished");
        }

        /**
         * use of class and not of a struct, to ensure it lays on the heap
         */ 
        class Splitter
        {
            public int lineIdx;
            private int _charIdx;
            public int charIdx
            {
                get => goesStraightDown ? _charIdx : isLeftChecked ? _charIdx + 1 : _charIdx - 1;
                set => _charIdx = value;
            }
            public bool isLeftChecked;
            public bool goesStraightDown = false;
        }

        public static int start4(string file)
        {
            var field = File.ReadAllLines(@"data\07\" + file);
            var start = 0;
            for (int i = 0; i < field[0].Length; i++)
            {
                if (field[0][i] == 'S')
                {
                    start = i;
                    break;
                }
            }

            var counter = 0;
            Stack<Splitter> splitters = new Stack<Splitter>();
            Splitter? last = new Splitter { charIdx = start, lineIdx = 1, isLeftChecked = false, goesStraightDown = true };

            void goBackTimeline()
            {
                if (!splitters.TryPop(out last))
                    last = null;
                else if (!last.isLeftChecked)
                    last.isLeftChecked = true;
                else
                    goBackTimeline();
            }

            for (int i = last.lineIdx; true; i++)
            {
                if (i == field.Length - 1)
                {
                    counter++;
                    goBackTimeline();
                    if (last == null)
                        break;
                    else
                        i = last.lineIdx;
                }
                else if (field[i][last.charIdx] == '^')
                {
                    splitters.Push(last);
                    last = new Splitter { charIdx = last.charIdx, lineIdx = i, isLeftChecked = false };
                    i--;
                }
            }
            return counter;
        }

        private class TreeNode
        {
            public int charIdx;
            public int lineIdx;
            public TreeNode? left { get; set; }
            public TreeNode? right { get; set; }
            private int? _amountOfTimelinesContained;
            public int amountOfTimelinesContained
            {
                get
                {
                    if (_amountOfTimelinesContained == null)
                    {
                        if (left == null && right == null)
                        {
                            return 1;
                        } else
                        {
                            return
                                (left == null ? 0 : left.amountOfTimelinesContained) +
                                (right == null ? 0 : right.amountOfTimelinesContained);
                        }
                    } else
                    {
                        return (int) _amountOfTimelinesContained;
                    }
                }
                set
                {
                    _amountOfTimelinesContained = value;
                }
            }

        }

        public static int start5(string file)
        {
            var field = File.ReadAllLines(@"data\07\" + file);
            var root = new TreeNode { lineIdx = 0 };
            var latestNode = root;
            for (int i = 0; i < field[0].Length; i++)
            {
                if (field[0][i] == 'S')
                {
                    root.charIdx = i;
                    break;
                }
            }

            for (int i = 1; i < field.Length; i++)
            {

            }

            return root.amountOfTimelinesContained;
        }
    }
}
