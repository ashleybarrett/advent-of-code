using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day06 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var groupAnswers = await FileInputHelper.GetInput("Input/day-06.txt");
            var groupAnswersLength = groupAnswers.Length;
            var groupSum = 0;

            var answers = new List<char>();

            for (int i = 0; i <= groupAnswersLength; i++)
            {
                if(i == groupAnswersLength || string.IsNullOrWhiteSpace(groupAnswers[i]))
                {
                    groupSum += answers.Distinct().Count();
                    answers = new List<char>();
                }
                else
                {
                    answers.AddRange(groupAnswers[i].ToList());
                }
            }

            return groupSum;
        }

        public async Task<long> SolvePartTwo()
        {
            var groupAnswers = await FileInputHelper.GetInput("Input/day-06.txt");
            var groupAnswersLength = groupAnswers.Length;            
            var groupSum = 0;

            var answers = new List<char>();
            var size = 0;

            for (int i = 0; i <= groupAnswersLength; i++)
            {
                if(i == groupAnswersLength || string.IsNullOrWhiteSpace(groupAnswers[i]))
                {
                    groupSum += answers.GroupBy(x => x).Where(x => x.Count() == size).Count();
                    size = 0;
                    answers = new List<char>();
                }
                else
                {
                    answers.AddRange(groupAnswers[i].ToList());
                    size++;
                }
            }

            return groupSum;
        }
    }
}