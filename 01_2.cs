namespace aoc2025
{
    internal class _01_2
    {
        public static int start(string file)
        {
            string[] data = File.ReadAllLines(@"data\01\" + file);
            int zerosHit = 0;

            int mod(int x, int m)
            {
                return (x % m + m) % m;
            }

            data.Select(val => (val[0] == 'L' ? -1 : 1) * int.Parse(val.Substring(1))).Aggregate(50, (sum, val) =>
            {
                int newVal = val;
                zerosHit += Math.Abs(val) / 100;
                int newSum = sum + (val % 100);
                if ((newSum <= 0 && sum != 0) || (100 <= newSum && sum != 100))
                {
                    zerosHit++;
                }
                return mod(newSum, 100);
            });
            return zerosHit;
        }
    }
}
