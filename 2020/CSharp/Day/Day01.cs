using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day01 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            const int breaker = 2020;

            var input = 
                (await File.ReadAllLinesAsync("Input/Day01.txt"))
                .Select(i => int.Parse(i));
            
            foreach(var a in input)
            {
                foreach(var b in input)
                {
                    if((a + b) == breaker)
                    {
                        return a * b;
                    }
                }
            }

            return -1;
        }

        public async Task<long> SolvePartTwo()
        {
            const int breaker = 2020;

            var input = 
                (await File.ReadAllLinesAsync("Input/Day01.txt"))
                .Select(i => int.Parse(i));
            
            foreach(var a in input)
            {
                foreach(var b in input)
                {
                    foreach(var c in input)
                    {
                        if((a + b + c) == breaker)
                        {
                            return a * b * c;
                        }
                    }
                }
            }

            return -1;
        }
    }
}