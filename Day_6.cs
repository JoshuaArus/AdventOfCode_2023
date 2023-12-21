using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2023
{
    public class Day_6 : Day
    {
        public override long FirstPart()
        {
            long res = 1;
            List<long> times = inputs[0].Split(":")[1].Trim().Split(" ").Where(t => !string.IsNullOrWhiteSpace(t)).Select(t => long.Parse(t.Trim())).ToList();
            List<long> records = inputs[1].Split(":")[1].Trim().Split(" ").Where(t => !string.IsNullOrWhiteSpace(t)).Select(t => long.Parse(t.Trim())).ToList();

            for (int i = 0; i < times.Count; i++)
            {   
                long possibleWays = 0;

                for (int j = 0; j < times[i]; j++)
                {
                    long boatSpeed = j;
                    long currentDistance = (times[i] - j) * boatSpeed;

                    if (currentDistance > records[i]) possibleWays++;
                }

                res *= possibleWays;
            }

            return res;
        }

        public override long SecondPart()
        {
            long res = -1;

            return res;
        }
    }
}
