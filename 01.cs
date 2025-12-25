namespace aoc2025
{
    internal class _01
    {
        public static int start(string file)
        {
            string[] data = File.ReadAllLines(@"data\01\" + file);
            int zerosHit = 0;
            data.Select(val => (val[0] == 'L' ? -1 : 1) * int.Parse(val.Substring(1))).Aggregate(50, (sum, val) =>
            {
                sum = (sum + val) % 100;
                if (sum == 0)
                {
                    zerosHit++;
                }
                return sum;
            });
            return zerosHit;
        }
    }
}
