using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day05 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var boardingPasses = await FileInputHelper.GetInput("Input/day-05.txt");
            long highestSeatId = 0;

            foreach(var boardingPass in boardingPasses)
            {
                var seatId = GetSeatId(boardingPass);

                if(seatId > highestSeatId) highestSeatId = seatId;
            }

            return highestSeatId;
        }

        public async Task<long> SolvePartTwo()
        {
            var boardingPasses = await FileInputHelper.GetInput("Input/day-05.txt");
            var seatIds = boardingPasses.Select(s => GetSeatId(s)).ToList();
            seatIds.Sort();

            for (int i = 0; i < seatIds.Count; i++)
            {
                if(seatIds[i+1] - seatIds[i] > 1)
                {
                    return seatIds[i] + 1;
                }
            }

            return -1;
        }

        private long GetSeatId(string boardingPass)
        {
            var chars = boardingPass.ToCharArray();
            var seatRow = GetSeatPart(chars[0..7], 0, 127, 'F');
            var seatColumn = GetSeatPart(chars[7..], 0, 7, 'L');

            return seatRow * 8 + seatColumn;
        }

        private int GetSeatPart(char[] chars, int min, int max, char lowerSector)
        {
            var diff = max - min;
            var half = diff / 2;

            if(diff == 0) return min;
            
            if(chars[0] == lowerSector)
            {
                return GetSeatPart(chars[1..], min, min + half, lowerSector);
            }
            else
            {
                return GetSeatPart(chars[1..], (min + half) + 1, max, lowerSector);
            }
        }
    }
}