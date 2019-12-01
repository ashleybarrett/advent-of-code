namespace AdventOfCode.Helpers

module File = 

    let readFileAndSplit (fileName: string) =  System.IO.File.ReadAllLines fileName 