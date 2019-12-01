module Day01
open AdventOfCode.Helpers.File

let solution =

    let filePath = sprintf "%s/%s" __SOURCE_DIRECTORY__ "Input.txt"

    let readFileLines = readFileAndSplit filePath |> Array.map int

    let getFuelRequiredForModule (mass: int) = mass / 3 - 2

    let partOne = readFileLines |> Array.sumBy getFuelRequiredForModule

    let partTwo = 

        let getTotalFuelRequiredForModule (mass: int) = 
            (0,mass)
            |> Seq.unfold(fun (acc, ele) -> 
                let fuelForModule = getFuelRequiredForModule ele
                let runningTotal = fuelForModule + acc
                Some((runningTotal, fuelForModule), (runningTotal, fuelForModule))
            )
            |> Seq.takeWhile(fun (_, ele) -> ele > 0)
            |> Seq.last
            |> fst
            
        readFileLines |> Array.sumBy getTotalFuelRequiredForModule

    (partOne, partTwo)

    
    
    
