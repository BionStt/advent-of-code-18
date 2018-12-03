using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using challenge_3_part_1;

namespace challenge_3_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a file name: ");
            var fileName = Console.ReadLine();
            var lines = File.ReadLines(fileName);
            var claimStore = new Dictionary<Tuple<int, int>, List<int>>();
            var idStore = new Dictionary<int, bool>();
            foreach(var line in lines)
            {
                var claimId = int.Parse(line.between('#', '@'));
                idStore.Add(claimId, true);
                var claim = Claim.translateClaim(line);
                for(var i = 0; i < claim.height; i++) 
                {
                    for (var j = 0; j < claim.width; j++)
                    {
                        var pointCoords = new Tuple<int, int>(claim.top + i, claim.left + j);
                        try
                        {
                            claimStore[pointCoords].Add(claimId);
                            foreach(var id in claimStore[pointCoords])
                            {
                                idStore[id] = false;
                            }
                        }
                        catch (KeyNotFoundException)
                        {
                            claimStore.Add(pointCoords, new List<int> { claimId });
                        }
                    }
                }
            }
            Console.WriteLine(idStore.Where(o => o.Value).FirstOrDefault());
        }
    }
}
