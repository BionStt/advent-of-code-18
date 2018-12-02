using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_1_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a file name: ");
            var fileName = Console.ReadLine();
            var lines = File.ReadLines(fileName);
            var freq = 0;
            var freqStore = new List<int>();
            freqStore.Add(freq);
            var notFound = true;
            while (notFound)
            {
                foreach (var line in lines)
                {
                    freq += int.Parse(line);
                    if (freqStore.Contains(freq))
                    {
                        notFound = false;
                        break;
                    }
                    freqStore.Add(freq);
                }
            }
            Console.WriteLine(freq);
        }
    }
}
