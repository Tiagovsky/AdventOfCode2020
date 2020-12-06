module Program

open Common.Files
open System


let getTotalAnswersInGroup answers =
    answers
    |> explode
    |> Array.distinct
    |> Array.filter Char.IsLetter
    |> Array.length

let calculatePart1 answers =
    answers
    |> Array.map getTotalAnswersInGroup
    |> Array.sum

let calculatePart1FromFile filePath =
    let fileContent = readFile filePath
    
    fileContent.Split ($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
    |> calculatePart1

let getCommonAnswersInGroup (answers:string) =
    let numLines = answers.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length

    answers
    |> explode
    |> Array.filter Char.IsLetter
    |> Array.countBy (fun c -> c)
    |> Array.filter (fun (_,count) -> count = numLines)
    |> Array.length

let calculatePart2 answers =
    answers
    |> Array.map getCommonAnswersInGroup
    |> Array.sum

let calculatePart2FromFile filePath =
    let fileContent = readFile filePath
    
    fileContent.Split ($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
    |> calculatePart2