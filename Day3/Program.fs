module Program

open Common.Files

let rec countTrees acc currentIndex rightMove downMove (path: char[][]) =
    let getNextIndex line =
        if (currentIndex + rightMove >= Array.length line) then
            currentIndex + rightMove - Array.length line
        else
            currentIndex + rightMove

    if (Array.length path = 0) then 
        int64(acc)
    else
        let currentLine = path.[0]
        let isTree = currentLine.[currentIndex] = '#'
        let treeCount = if isTree then 
                            (acc + 1) 
                        else acc

        countTrees treeCount (getNextIndex currentLine) rightMove downMove path.[downMove ..]


let calculatePart1 path =
    countTrees 0 0 3 1 path

let calculatePart1FromFile filePath =
    getLineValuesFromFilePath filePath
    |> Array.map explode
    |> calculatePart1


let calculatePart2 path =
    countTrees 0 0 1 1 path
    * countTrees 0 0 3 1 path
    * countTrees 0 0 5 1 path
    * countTrees 0 0 7 1 path
    * countTrees 0 0 1 2 path

let calculatePart2FromFile filePath =
    getLineValuesFromFilePath filePath
    |> Array.map explode
    |> calculatePart2
