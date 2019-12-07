namespace AdventOfCode.Solutions

module Day02 = 
    open AdventOfCode.Helpers.File

    let solution =

        let filePath = sprintf "%s/%s" __SOURCE_DIRECTORY__ "Input.txt"

        let input = 
            readSingleLineFileAndSplit filePath ','
            |> Array.map int

        let rec processLines (currentInput: int array) (mutableInput: int array) = 
            let chunk = currentInput |> Array.take 4
            let opcode = chunk.[0]
            let numberOne = chunk.[1]
            let numberTwo = chunk.[2]
            let position = chunk.[3]


            match opcode with
            | 1 -> 
                mutableInput.[position] <- mutableInput.[numberOne] + mutableInput.[numberTwo]
                let next = currentInput |> Array.skip 4

                processLines next mutableInput
            | 2 -> 
                mutableInput.[position] <- mutableInput.[numberOne] * mutableInput.[numberTwo]

                let next = currentInput |> Array.skip 4

                processLines next mutableInput

            | _ -> mutableInput

        let replacePair (addressOne: int) (addressTwo: int) (input: int array) = 
            input.[1] <- addressOne
            input.[2] <- addressTwo

            input


        let partOne = 
            let mutable mutableInput = 
                readSingleLineFileAndSplit filePath ','
                |> Array.map int 
                |> replacePair 12 2
            
            processLines mutableInput mutableInput |> Array.head

        let partTwo = 
            
            let values = [|0..99|]

            let (noun, verb) = 
                seq {
                    for numberOne in values do
                    for numberTwo in values do
                        yield (numberOne, numberTwo)
                } 
                |> Seq.find(fun (addressOne, addressTwo) -> 

                    let mutable mutableInput = 
                        readSingleLineFileAndSplit filePath ','
                        |> Array.map int 
                        |> replacePair addressOne addressTwo
                    
                    let valueToMatch = 19690720
                    
                    let positionZero = processLines mutableInput mutableInput |> Array.head
                    
                    positionZero = valueToMatch
                )

            100 * noun + verb

        (partOne, partTwo)

    
    
    
