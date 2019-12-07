namespace AdventOfCode.Tests

open NUnit.Framework
open Shouldly
open AdventOfCode.Solutions

[<TestFixture>]
type VerifySolution () =

    [<Test>]
    member this.VerifyDay01() =
        let expectedPartOne = 3317100
        let expectedPartTwo = 4972784
        let (actualPartOne, actualPartTwo) = Day01.solution

        actualPartOne.ShouldBe(expectedPartOne);
        actualPartTwo.ShouldBe(expectedPartTwo);
    
    //[<Test>]
    //member this.VerifyDay02() =
    //    let expectedPartOne = 5098658
    //    let expectedPartTwo = 4972784
    //    let (actualPartOne, actualPartTwo) = AdventOfCode.Solutions.Day02.solution

    //    actualPartOne.ShouldBe(expectedPartOne);
    //    actualPartTwo.ShouldBe(expectedPartTwo);