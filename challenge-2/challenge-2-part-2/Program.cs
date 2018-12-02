using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_2_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a file name: ");
            var fileName = Console.ReadLine();
            var lines = new List<string>(File.ReadAllLines(fileName));
            bool pairFound = false;
            var code1 = "";
            var code2 = "";
            foreach(var outerLine in lines)
            {
                if (pairFound)
                {
                    break;
                }
                foreach(var innerLine in lines)
                {
                    if (differenceCount(outerLine, innerLine) == 1)
                    {
                        code1 = outerLine;
                        code2 = innerLine;
                        pairFound = true;
                        break;
                    }
                }
            }
            var commonChars = "";
            for (var i = 0; i < code1.Length; i++) 
            {
                if (code1[i] == code2[i])
                {
                    commonChars += code1[i];
                }
            }
            Console.WriteLine(code1);
            Console.WriteLine(code2);
            Console.WriteLine("-------");
            Console.WriteLine(commonChars);
        }

        static int differenceCount(string a, string b)
        {
            var count = 0;
            if (a.Length != b.Length)
            {
                throw new Exception(a + " and " + b + " not same length");
            }
            for(var i = 0; i< a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
