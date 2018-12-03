using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_3_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a file name: ");
            var fileName = Console.ReadLine();
            var lines = File.ReadLines(fileName);
            var claimStore = new Dictionary<Tuple<int,int>, int>();
            foreach(var line in lines)
            {
                var claim = Claim.translateClaim(line);
                for (var i = 0; i < claim.height; i++) 
                {
                    for (var j = 0; j < claim.width; j++) 
                    {
                        var pointCoords = new Tuple<int, int>(claim.top + i, claim.left + j);
                        try
                        {
                            claimStore[pointCoords]++;
                        }
                        catch(KeyNotFoundException)
                        {
                            claimStore.Add(pointCoords, 1);
                        }
                    }
                }
            }
            var answer = claimStore.Where(o => o.Value >= 2).Count();
            Console.WriteLine(answer);
        }

    }
    public class Claim
    {
        public Claim(int _left, int _top, int _width, int _height)
        {
            top = _top;
            left = _left;
            width = _width;
            height = _height;
        }

        public static Claim translateClaim(string claimString)
        {

            return new Claim(
                int.Parse(claimString.between('@', ',')),
                int.Parse(claimString.between(',', ':')),
                int.Parse(claimString.between(':', 'x')),
                int.Parse(claimString.Substring(claimString.IndexOf('x') + 1))
            );
        }

        public int top, left, width, height;
    }

    public static class Extension
    {
        public static string between(this string source, char start, char end)
        {
            int startPos = source.IndexOf(start);
            int endPos = source.IndexOf(end);
            if (startPos < 0 || endPos < 0 || endPos < startPos + 1)
            {
                throw new ArgumentException("Bad indexing of " + source + " from " + start.ToString() + " to " + end.ToString());
            }
            return source.Substring(startPos + 1, endPos - startPos - 1);
        }
    }
}
