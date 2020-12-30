using System.Collections.Generic;
using System.Threading.Tasks;
using CSharp.Day;
using NUnit.Framework;
using Shouldly;

namespace CSharp
{
    public class Tests
    {
        [TestCaseSource(nameof(GetCases))]
        public async Task Solve(IDayPuzzle day, long partOneExpected, long partTwoExpected)
        {
            var partOneActual = await day.SolvePartOne();
            var partTwoActual = await day.SolvePartTwo();

            partOneActual.ShouldBe(partOneExpected);
            partTwoActual.ShouldBe(partTwoExpected);
        }

        private static IEnumerable<object[]> GetCases() 
        {

            yield return new object[]
            {
                new Day05(),
                951,
                653
            };

            yield return new object[]
            {
                new Day04(),
                219,
                127
            };

            yield return new object[]
            {
                new Day03(),
                234,
                5813773056
            };

            yield return new object[]
            {
                new Day02(),
                660,
                530
            };

            yield return new object[]
            {
                new Day01(),
                73371,
                127642310
            };
        }
    }
}