namespace AdventOfCode.Helpers

module File = 

    let readFile (fileName: string) =  System.IO.File.ReadAllLines fileName

    let readSingleLineFileAndSplit (fileName: string) (spliter: char) =  
        let content = System.IO.File.ReadAllLines fileName |> Array.head

        content.Split(spliter)