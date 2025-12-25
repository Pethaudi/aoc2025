using System;
using System.Collections.Generic;
using System.Text;

namespace aoc2025
{
    internal class _04
    {
        public static long start(string file)
        {
            var field = File.ReadAllLines(@"data\04\" + file);

            long counter = 0;
            HashSet<(int i, int j)> indizes = new HashSet<(int i, int j)>();
            long localCounter = 0;

            void check(int i, int j)
            {
                if (field[i][j] == '@')
                {
                    localCounter++;
                }
            }

            void checkJ(int i, int j, bool noEqualCheck = false)
            {
                if (0 < j)
                {
                    check(i, j - 1);
                }

                if (!noEqualCheck)
                {
                    check(i, j);
                }

                if (j < field[i].Length - 1)
                {
                    check(i, j + 1);
                }
            }

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (i == 1 && j == 4)
                    {
                        Console.Write("");
                    }
                    if (field[i][j] == '@')
                    {

                        if (0 < i)
                        {
                            checkJ(i - 1, j);
                        }

                        checkJ(i, j, true);

                        if (i < field.Length - 1)
                        {
                            checkJ(i + 1, j);
                        }

                        if (localCounter < 4)
                        {
                            counter++;
                            indizes.Add((i, j));
                        }

                        localCounter = 0;
                    }

                }
            }

            return counter;
        }
    }
}
