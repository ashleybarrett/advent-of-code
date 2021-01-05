using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day08 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var instructions = await FileInputHelper.GetInput("Input/day-08.txt");

            var accumulator = 0;
            var nextInstruction = 0;
            var instructionsRan = new List<int>();

            while(true)
            {
                if(instructionsRan.Contains(nextInstruction))
                {
                    break;
                }

                instructionsRan.Add(nextInstruction);

                var instructionParts = instructions[nextInstruction].Split(' ');
                var instructionType = instructionParts[0];
                var instructionValue = int.Parse(instructionParts[1]);

                if(instructionType == "acc")
                {
                    accumulator += instructionValue;
                    nextInstruction++;
                }
                else if(instructionType == "jmp")
                {
                    nextInstruction += instructionValue;
                }
                else
                {
                    nextInstruction++;
                }
            }

            return accumulator;
        }

        public async Task<long> SolvePartTwo()
        {
            var instructions = await FileInputHelper.GetInput("Input/day-08.txt");

            var accumulator = 0;
            var nextInstruction = 0;
            var instructionsRan = new List<int>();

            var swapInProgress = false;
            var instructionSwapped = 0;
            var swapsToSkip = new List<int>();

            while(true)
            {
                if(nextInstruction >= instructions.Length)
                {
                    break;
                }

                if(instructionsRan.Contains(nextInstruction))
                {
                    swapInProgress = false;
                    swapsToSkip.Add(instructionSwapped);
                    accumulator = 0;
                    nextInstruction = 0;
                    instructionsRan = new List<int>();
                }

                instructionsRan.Add(nextInstruction);

                var instructionParts = instructions[nextInstruction].Split(' ');
                var instructionType = instructionParts[0];
                var instructionValue = int.Parse(instructionParts[1]);

                if(!swapInProgress && !swapsToSkip.Contains(nextInstruction) && instructionType == "jmp")
                {
                    instructionType = "nop";
                    swapInProgress = true;
                    instructionSwapped = nextInstruction;
                }

                if(!swapInProgress && !swapsToSkip.Contains(nextInstruction) && instructionType == "nop")
                {
                    instructionType = "jmp";
                    swapInProgress = true;
                    instructionSwapped = nextInstruction;
                }

                if(instructionType == "acc")
                {
                    accumulator += instructionValue;
                    nextInstruction++;
                }
                else if(instructionType == "jmp")
                {
                    nextInstruction += instructionValue;
                }
                else
                {
                    nextInstruction++;
                }
            }

            return accumulator;
        }
    }
}