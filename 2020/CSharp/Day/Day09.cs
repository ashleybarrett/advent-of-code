using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day09 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var xmasNumbers = (await FileInputHelper.GetInput("Input/day-09.txt"))
                .Select(i => long.Parse(i))
                .ToArray();

            var preambleLength = 25;

            long number = 0;

            for (int i = preambleLength; i < xmasNumbers.Length; i++)
            {
                number = xmasNumbers[i];
                var preableLowerIndex = i - preambleLength;
                var preable = xmasNumbers.Skip(preableLowerIndex).Take(preambleLength);
                var match = false;

                foreach (var n in preable)
                {
                    foreach (var j in preable)
                    {
                        if(n == j) continue;

                        if(n + j == number)
                        {
                            match = true;
                            break;
                        }
                    }

                    if(match) break;
                }

                if(!match) break;
            }

            return number;  
        }

        public async Task<long> SolvePartTwo()
        {
            var xmasNumbers = (await FileInputHelper.GetInput("Input/day-09.txt"))
                .Select(i => long.Parse(i))
                .ToArray();

            var target = 18272118;
            long weakness = 0;

            for (int i = 0; i < xmasNumbers.Length; i++)
            {
                long run = xmasNumbers[i];
                long smallest = xmasNumbers[i];
                long largest = xmasNumbers[i];

                for (int j = (i + 1); j < xmasNumbers.Length; j++)
                {
                    run += xmasNumbers[j];

                    if(xmasNumbers[j] < smallest) smallest = xmasNumbers[j];
                    if(xmasNumbers[j] > largest) largest = xmasNumbers[j];

                    if(run >= target) break;
                }

                if(run == target)
                {
                    weakness = smallest + largest;
                }
            }

            return weakness;
        }
    }
}