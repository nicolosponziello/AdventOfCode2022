using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Day3
    {

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            var sum = 0;
            foreach (var line in lines)
            {
                var duplicateItem = ' ';
                var firstCompartment = line.Substring(0, line.Length / 2);
                var secondCompartment = line.Substring(line.Length / 2, line.Length / 2);
                foreach (var item in firstCompartment)
                {
                    if (secondCompartment.Contains(item))
                    {
                        duplicateItem = item;
                        break;
                    }
                }
                sum += Priority(duplicateItem);
            }
            Console.WriteLine(sum);
            sum = 0;
            for (var i = 0; i < lines.Length; i+=3)
            {
                foreach(var c in lines[i])
                {
                    if (lines[i+1].Contains(c) && lines[i+2].Contains(c))
                    {
                        //badge found
                        sum += Priority(c);
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }

        static int Priority(char c)
        {
            if (Char.IsUpper(c))
            {
                return c - 'A' + 27;
            }
            else
            {
                return c - 'a' + 1;
            }
            return 0;
        }
    }
}
