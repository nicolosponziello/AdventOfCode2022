using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{ 
    public class Day4
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            var countContained = 0;
            var countOverlapping = 0;
            foreach(var line in lines)
            {
                var intervals = line.Split(',');
                (int, int) interval1 = ParseInterval(intervals[0]);
                (int, int) interval2 = ParseInterval(intervals[1]);

                if (CheckContained(interval1, interval2))
                {
                    countContained++;
                }
                if (CheckOverlapping(interval1, interval2))
                {
                    countOverlapping++;
                }

            }
            Console.WriteLine(countContained);
            Console.WriteLine(countOverlapping);
        }

        static bool CheckContained((int, int) x, (int, int) y)
        {
            return (x.Item1 >= y.Item1 && x.Item2 <= y.Item2) || (y.Item1 >= x.Item1 && y.Item2 <= x.Item2);
        }

        static bool CheckOverlapping((int, int) x, (int, int) y)
        {
            var xRange = Enumerable.Range(x.Item1, x.Item2 - x.Item1 + 1);
            var yRange = Enumerable.Range(y.Item1, y.Item2 - y.Item1 + 1);

            return yRange.Contains(x.Item1) || yRange.Contains(x.Item2) || xRange.Contains(y.Item1) || xRange.Contains(y.Item2);
        }

        static (int, int) ParseInterval(string i)
        {
            var values = i.Split('-');
            return (int.Parse(values[0]), int.Parse(values[1]));
        }
    }
}
