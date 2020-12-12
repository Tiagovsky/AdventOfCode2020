module Program

open Common.Files

let calculatePart1 preamble (numbers:int64[]) =
    let isInvalid index =
        numbers.[index - preamble .. index - 1]
        |> combine
        |> Array.exists (fun (a,b) -> a + b = numbers.[index])
        |> not

    let invalidIndex = [|preamble .. Array.length numbers - 1|]
                        |> Array.find isInvalid

    numbers.[invalidIndex]

let calculatePart2 preamble (numbers:int64[]) =
    let invalidNumber = calculatePart1 preamble numbers
    let maxIndex = Array.length numbers - 1

    let getMinMaxSum minIndex maxIndex =
        let arraySubset = numbers.[minIndex .. maxIndex]
        
        Array.min arraySubset + Array.max arraySubset

    let mutable found = int64 0

    for i = 0 to maxIndex do
        let mutable sum = numbers.[i]
        let mutable j = i + 1
        while (sum < invalidNumber && j <= maxIndex) do
            sum <- sum + numbers.[j]
            if (sum = invalidNumber) then
                found <- getMinMaxSum i j
            else 
                j <- j + 1
     
    found

let calculatePart1FromFile preamble filePath =
    filePath
    |> getLineValuesFromFilePath
    |> Array.map int64
    |> calculatePart1 preamble

let calculatePart2FromFile preamble filePath =
    filePath
    |> getLineValuesFromFilePath
    |> Array.map int64
    |> calculatePart2 preamble
