module Tests

open Xunit
open Program
open System

[<Fact>]
let ``Calculate Part1 Test Case`` () =
    let result = calculatePart1FromFile 5 "inputTest.txt"
    Assert.Equal (int64 127, result)

[<Fact>]
let ``Real Case Part1`` () =
    let result = calculatePart1FromFile 25 "input.txt"

    Console.WriteLine result

[<Fact>]
let ``Calculate Part2 Test Case`` () =
    let result = calculatePart2FromFile 5 "inputTest.txt"
    Assert.Equal (int64 62, result)

[<Fact>]
let ``Real Case Part2`` () =
    let result = calculatePart2FromFile 25 "input.txt"

    Console.WriteLine (result)