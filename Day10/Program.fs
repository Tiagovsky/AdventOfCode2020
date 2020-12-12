module Program

open Common.Files

let calculateDifference (numbers:int[]) i v =
    match i with
    | 0 -> v
    | _ -> v - numbers.[i - 1]

let calculatePart1 (numbers:int[]) =
    let multiplyJolts arr =
        let count1Jolt = snd <| Array.find (fun (v,_) -> v = 1) arr
        let count3Jolt = snd <| Array.find (fun (v,_) -> v = 3) arr
        count1Jolt * (count3Jolt + 1)

    let sortedNumbers = numbers |> Array.sort
    sortedNumbers
    |> Array.mapi (calculateDifference sortedNumbers)
    |> Array.countBy id
    |> multiplyJolts

let calculatePart1FromFile filePath =
    filePath
    |> getLineValuesFromFilePath
    |> Array.map int
    |> calculatePart1

let rec countCombinations differences :int64 =
    match differences with
    | 1 :: 1 :: 1 :: 1 :: l -> int64 7 * countCombinations l
    | 1 :: 1 :: 1 :: l -> int64 4 * countCombinations l
    | 1 :: 1 :: l -> int64 2 * countCombinations l
    | _ :: l -> countCombinations l
    | [] -> int64 1

let calculatePart2 (numbers:int[]) =
    let sortedNumbers = numbers |> Array.sort
    sortedNumbers
    |> Array.mapi (calculateDifference sortedNumbers)
    |> List.ofArray
    |> countCombinations

let calculatePart2FromFile filePath =
    filePath
    |> getLineValuesFromFilePath
    |> Array.map int
    |> calculatePart2
