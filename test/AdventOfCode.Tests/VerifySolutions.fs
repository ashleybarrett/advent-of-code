namespace AdventOFCode.Tests

open NUnit.Framework
open Shouldly

[<TestFixture>]
type TestClass () =

    [<Test>]
    member this.VerifySolution1() =
        let expectedPartOne = 3317100
        let expectedPartTwo = 4972784
        let (actualPartOne, actualPartTwo) = Day01.solution

        actualPartOne.ShouldBe(expectedPartOne);
        actualPartTwo.ShouldBe(expectedPartTwo);