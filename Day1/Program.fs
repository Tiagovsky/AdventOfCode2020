module Program

open Common.Files

let getPairElementCombinations expenses element = 
    expenses |> Array.map (fun e -> (element, e))

let calculatePart1 desiredSum (expenses:int[]) =
    let isDesiredSum (val1,val2) = 
        val1 + val2 = desiredSum

    let (val1, val2) = expenses
                    |> Array.collect (getPairElementCombinations expenses)
                    |> Array.find isDesiredSum;

    val1 * val2;

let calculatePart2 desiredSum (expenses:int[]) =
    let isDesiredSum (val1,val2,val3) = 
        val1 + val2 + val3 = desiredSum

    let getThreeElementCombinations element =
        expenses
        |> Array.collect (getPairElementCombinations expenses)
        |> Array.map (fun (x,y) -> (x, y, element))

    let (val1, val2, val3) = expenses
                            |> Array.collect getThreeElementCombinations
                            |> Array.find isDesiredSum;

    val1 * val2 * val3;

let calculatePart1FromFile filePath =
    getLineValuesFromFilePath filePath
    |> Array.map int
    |> calculatePart1 2020

let calculatePart2FromFile filePath =
    getLineValuesFromFilePath filePath
    |> Array.map int
    |> calculatePart2 2020