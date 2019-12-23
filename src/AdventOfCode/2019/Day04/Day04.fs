module Day04

open AdventOfCode.Helpers.File

let solution =

    let (min, max) = (134564, 585159)
    
    let rec doesNotDecrease (number: int) (remainingDigits: int list) = 
        match remainingDigits with
        | [] -> true
        | head::tail -> 
            match head with
            | _ when number > head -> false
            | _ -> doesNotDecrease head tail

    let rec matchesRules (digits: int list) (countFunc: int * int -> bool) = 
        let hasTwoMatchingDigits = 
            digits
            |> List.countBy id
            |> List.exists(countFunc)
         
        hasTwoMatchingDigits && doesNotDecrease digits.Head digits.Tail

    let generatePasswordsCount (countFunc: int * int -> bool) = 
        [min..max]
        |> List.filter(fun number -> 
            let digits = (number |> string).ToCharArray() |> Array.map int |> List.ofArray
            matchesRules digits countFunc
        )
        |> List.length     

    let partOne = generatePasswordsCount <| fun (_, count) -> count >= 2

    let partTwo = generatePasswordsCount <| fun (_, count) -> count = 2

    (partOne, partTwo)

    
    
    
