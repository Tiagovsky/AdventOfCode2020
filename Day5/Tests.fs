module Tests

open Xunit
open Program
open System
open Common.Files

[<Theory>]
[<InlineData("FBFBBFFRLR", 357)>]
[<InlineData("BFFFBBFRRR", 567)>]
[<InlineData("FFFBBBFRRR", 119)>]
[<InlineData("BBFFBBFRLL", 820)>]
let ``Calculate Part1 Test Case`` (code, expected) =
    let result = calculateId <| calculateSeat (explode code)
    Assert.Equal (expected, result)

[<Fact>]
let ``Real Case Part1`` () =
    let result = calculatePart1FromFile "input.txt"
    Console.WriteLine result

//[<Fact>]
//let ``Calculate Part2 Test Case`` () =
//    let result = calculatePart2FromFile "inputTest2.txt"
//    Assert.Equal (4, result)

[<Fact>]
let ``Real Case Part2`` () =
    let result = calculatePart2FromFile "input.txt"
    Console.WriteLine (result - 1)