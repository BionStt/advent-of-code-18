using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a file name: ");
            var fileName = Console.ReadLine();
            var lines = File.ReadLines(fileName);
            var twoCount = 0;
            var threeCount = 0;
            foreach(var line in lines)
            {
                var twoFound = false;
                var threeFound = false;
                foreach(var _char in line)
                {
                    var charCount = line.Count(o => o == _char);
                    if(charCount == 2 && !twoFound)
                    {
                        twoFound = true;
                        twoCount++;
                    }
                    if(charCount == 3 && !threeFound)
                    {
                        threeFound = true;
                        threeCount++;
                    }
                }
            }
            Console.WriteLine(twoCount * threeCount);
        }
    }
}
