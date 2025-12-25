using System;
using System.Collections.Generic;
using System.Text;

namespace aoc2025
{
    internal class _04_2
    {
        public static long start(string file)
        {
            var field = File.ReadAllLines(@"data\04\" + file);

            long counter = 0;
            long prevCounter = -1;
            HashSet<(int i, int j)> indizes = new HashSet<(int i, int j)>();
            long localCounter = 0;

            void markRemoved(bool temp = false)
            {
                foreach (var (i, j) in indizes)
                {
                    string res = "";
                    for (int jRepl = 0; jRepl < field[i].Length; jRepl++)
                    {
                        if (temp)
                        {
                            if (field[i][jRepl] == '@')
                            {
                                res += j == jRepl ? 'O' : field[i][jRepl];
                            } else
                            {
                                res += field[i][jRepl];
                            }
                        } else
                        {
                            res += j == jRepl ? 'X' : field[i][jRepl];
                        }
                    }
                    field[i] = res;
                }
            }

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

            do
            {
                prevCounter = counter;
                for (int i = 0; i < field.Length; i++)
                {
                    for (int j = 0; j < field[i].Length; j++)
                    {
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
                /* markRemoved(true);
                for (int i = 0; i < field.Length; i++)
                {
                    for (int j = 0; j < field[i].Length; j++)
                    {
                        if (field[i][j] == '@')
                        {
                            if (indizes.Contains((i, j)))
                            {
                                Console.Write('X');
                            }
                            else
                            {
                                Console.Write('@');
                            }
                        }
                        else
                        {
                            Console.Write(field[i][j]);
                        }
                    }
                    Console.WriteLine();
                } */
                // System.Threading.Thread.Sleep(5000);
                markRemoved();
                // Console.WriteLine("{0}/{1}", prevCounter, counter);
            } while (prevCounter != counter);


            return counter;
        }
    }
}
