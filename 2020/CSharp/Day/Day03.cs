using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day03 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var input = await FileInputHelper.GetInput("Input/day-03.txt");
            var inputAsArray = InputToArray(input);

            return GetNumberOfTreesEncountered(inputAsArray, 3, 1);
        }

        public async Task<long> SolvePartTwo()
        {
            var input = await FileInputHelper.GetInput("Input/day-03.txt");
            var inputAsArray = InputToArray(input);

            var total = 
                GetNumberOfTreesEncountered(inputAsArray, 1, 1) *
                GetNumberOfTreesEncountered(inputAsArray, 3, 1) *
                GetNumberOfTreesEncountered(inputAsArray, 5, 1) *
                GetNumberOfTreesEncountered(inputAsArray, 7, 1) *
                GetNumberOfTreesEncountered(inputAsArray, 1, 2);

            return total;
        }

        private char[][] InputToArray(string[] input)
            => input.Select(i => i.ToCharArray()).ToArray();

        private long GetNumberOfTreesEncountered(char[][] inputAsArray, int right, int down)
        {
            var rows = inputAsArray.Length - 1;
            var indexes = inputAsArray[0].Length - 1;

            int rowPosition = 0, indexPosition = 0, numberOfTreesEncountered = 0;

            while(true)
            {
                rowPosition += down;
                indexPosition += right;

                if(rowPosition > rows)
                {
                    break;
                }

                if(indexPosition > indexes)
                {
                    indexPosition = (indexPosition - indexes) - 1;
                }

                if(inputAsArray[rowPosition][indexPosition] == '#')
                {
                    numberOfTreesEncountered++;
                }
            }

            return numberOfTreesEncountered;
        }
    }
}