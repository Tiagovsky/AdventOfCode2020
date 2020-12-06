module Tests

open Xunit
open Program
open System

[<Fact>]
let ``Calculate Part1 Test Case`` () =
    let result = calculatePart1FromFile "inputTest.txt"
    Assert.Equal (11, result)

[<Fact>]
let ``Real Case Part1`` () =
    let result = calculatePart1FromFile "input.txt"
    Console.WriteLine result

[<Fact>]
let ``Calculate Part2 Test Case`` () =
    let result = calculatePart2FromFile "inputTest.txt"
    Assert.Equal (6, result)

[<Fact>]
let ``Real Case Part2`` () =
    let result = calculatePart2FromFile "input.txt"
    Console.WriteLine (result)