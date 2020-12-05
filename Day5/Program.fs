module Program

open Common.Files
open System

let rec calculateFromRange lowChar highChar (minRange:decimal) (maxRange:decimal) (values:char[]) =
    if minRange = maxRange then
        minRange
    else
        match values.[0] with
            | x when x = lowChar -> calculateFromRange lowChar highChar minRange (floor (maxRange-(maxRange-minRange)/decimal(2))) values.[1 ..]
            | y when y = highChar ->  calculateFromRange lowChar highChar (ceil (minRange+(maxRange-minRange)/decimal(2))) maxRange values.[1 ..]
            | _ -> minRange

let calculateSeat (seatCode:char[]) =
    let row = calculateFromRange 'F' 'B' (0|>decimal) (127|>decimal) seatCode.[0..6]
    let column = calculateFromRange 'L' 'R' (0|>decimal) (7|>decimal) seatCode.[7..9]
    (row|>int,column|>int)

let calculateId seat =
    fst seat * 8 + snd seat

let calculatePart1 seatCodes =
    seatCodes
    |> Array.map explode
    |> Array.map calculateSeat
    |> Array.map calculateId
    |> Array.max

let calculatePart1FromFile filePath =
    filePath
    |> getLineValuesFromFilePath
    |> calculatePart1


let calculatePart2 seatCodes =
    seatCodes
    |> Array.map explode
    |> Array.map calculateSeat
    |> Array.map calculateId
    |> Array.sort
    |> Array.mapi (fun i v -> (i, v))
    |> Array.find (fun (i,v) -> i <> (v - 32))
    |> snd

let calculatePart2FromFile filePath =
    filePath
    |> getLineValuesFromFilePath
    |> calculatePart2

