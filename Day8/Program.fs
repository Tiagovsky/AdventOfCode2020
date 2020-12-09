module Program

open Common.Files

let parseInstruction (str:string) =
    let values = str.Split(" ");
    (values.[0], values.[1] |> int)

let rec processInstructions acc next executed (instructions:(string * int)[]) =
    let (instruction, value) = instructions.[next]

    if (List.contains next executed) then 
        acc
    else
        let executed = executed @ [next]

        match instruction with 
        | "nop" -> processInstructions acc (next + 1) executed instructions
        | "acc" -> processInstructions (acc + value) (next + 1) executed instructions
        | "jmp" -> processInstructions acc (next + value) executed instructions
        | _ -> acc

let calculatePart1 instructions =
    processInstructions 0 0 List.empty instructions

let rec isLoop acc next executed (instructions:(string * int)[]) =
    if (next = Array.length instructions) then (false, acc)
    else
        let instruction, value = instructions.[next]
    
        if (List.contains next executed) then 
            (true, acc)
        else
            let executed = executed @ [next]
    
            match instruction with 
            | "nop" -> isLoop acc (next + 1) executed instructions
            | "acc" -> isLoop (acc + value) (next + 1) executed instructions
            | "jmp" -> isLoop acc (next + value) executed instructions
            | _ -> (true, acc)

let calculatePart1FromFile filePath =
    filePath
    |> getLineValuesFromFilePath
    |> Array.map parseInstruction
    |> calculatePart1

let rec calculateNewInstructionSet index (instructions:(string * int)[]) =
    let mutable newInstructions = Array.copy instructions
    let instruction, value = instructions.[index]
    let mutable newIndex = index

    match instruction with 
    | "nop" -> newInstructions.[index] <- ("jmp", value)
    | "jmp" -> newInstructions.[index] <- ("nop", value)
    | "acc" -> (let inst, ind = calculateNewInstructionSet (index + 1) instructions
                newInstructions <- inst; newIndex <- ind)

    (newInstructions, newIndex)

let calculatePart2 instructions =
    let mutable stillInLoop = true
    let mutable acc = 0
    let mutable index = 0
    while (stillInLoop) do
        let newInstructionSet, i = calculateNewInstructionSet (index + 1) instructions
        index <- i
        let inL, newAcc = isLoop 0 0 List.empty newInstructionSet
        stillInLoop <- inL
        acc <- newAcc

    acc

let calculatePart2FromFile filePath =
    filePath
    |> getLineValuesFromFilePath
    |> Array.map parseInstruction
    |> calculatePart2

