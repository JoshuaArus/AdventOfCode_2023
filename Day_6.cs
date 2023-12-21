namespace AdventOfCode_2023
{
    public class Day_6 : Day
    {
        public override long FirstPart()
        {
            long res = 1;
            List<long> times = inputs[0]
                .Split(":")[1]
                .Trim()
                .Split(" ")
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Select(t => long.Parse(t.Trim()))
                .ToList();
            List<long> records = inputs[1]
                .Split(":")[1]
                .Trim()
                .Split(" ")
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Select(t => long.Parse(t.Trim()))
                .ToList();

            for (int i = 0; i < times.Count; i++)
                res *= CalculatePossibleWays(times[i], records[i]);

            return res;
        }

        public override long SecondPart()
        {
            long time = long.Parse(
                string.Join(
                    "",
                    inputs[0]
                    .Split(":")[1]
                    .Split(" ")
                    .Select(t => (t.Trim()))
                    .Where(t => !string.IsNullOrWhiteSpace(t))));

            long record = long.Parse(
                string.Join(
                    "",
                    inputs[1]
                    .Split(":")[1]
                    .Split(" ")
                    .Select(t => (t.Trim()))
                    .Where(t => !string.IsNullOrWhiteSpace(t))));

            return CalculatePossibleWays(time, record);
        }

        private static long CalculatePossibleWays(long time, long record)
        {
            long res = 0;

            for (int j = 0; j < time; j++)
            {
                long boatSpeed = j;
                long currentDistance = (time - j) * boatSpeed;

                if (currentDistance > record) res++;
            }

            return res;
        }
    }
}
