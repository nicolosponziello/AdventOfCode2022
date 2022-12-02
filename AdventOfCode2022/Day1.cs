using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Day1
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            var allCalories = new List<int>();
            var counting = 0;
            foreach(string line in lines)
            {
                if(string.IsNullOrWhiteSpace(line))
                {
                    allCalories.Add(counting);
                    counting = 0;
                }
                else
                {
                    counting += int.Parse(line);
                }
            }
            allCalories.Sort();
            allCalories.Reverse();
            Console.WriteLine(allCalories[0] + allCalories[1] + allCalories[2]);
        }
    }
}
