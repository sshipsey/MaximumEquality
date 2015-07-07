using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 4, 7, 9, 31 };
            MaximumEquality(input);
        }

        static void MaximumEquality(int[] cars)
        {
            int moves = 0;
            int maxIndex, minIndex;
            List<int> c = cars.ToList();
            List<int> tempC = new List<int>();

            //Initial print
            Console.WriteLine(PrintList(c));

            while (true)
            {
                maxIndex = c.IndexOf(c.Max());
                minIndex = c.IndexOf(c.Min());

                //copy c to tempC by value
                tempC = new List<int>();
                tempC.AddRange(c);

                c[minIndex]++;
                c[maxIndex]--;
                if (tempC.All(c.Contains))
                    break;

                ++moves;
                Console.WriteLine(PrintList(c) + " move #" + moves);
            }
            var equalCars = c.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Count()).First();

            Console.WriteLine("Equal cars: {0}\nNumber of moves: {1}", equalCars, moves);
            Console.ReadLine();
        }

        static string PrintList(List<int> l)
        {
            string retVal = "[ ";
            foreach (int o in l)
                retVal += (o + " ");
            retVal += "]";
            return retVal;
        }
    }
}

