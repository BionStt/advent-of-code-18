using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_1_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a file name: ");
            var fileName = Console.ReadLine();
            var lines = File.ReadLines(fileName);
            var freq = 0;
            foreach (var line in lines)
            {
                freq += int.Parse(line);
            }
            Console.WriteLine(freq);
        }
    }
}
