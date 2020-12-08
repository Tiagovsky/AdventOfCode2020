module Tests

open Xunit
open Program
open System

[<Fact>]
let ``Calculate Part1 Test Case`` () =
    let result = calculatePart1FromFile "shiny gold" "inputTest.txt"
    Assert.Equal (4, result)

[<Fact>]
let ``Real Case Part1`` () =
    let result = calculatePart1FromFile "shiny gold" "input.txt"
    Console.WriteLine result

[<Theory>]
[<InlineData("inputTest.txt", 32)>]
[<InlineData("inputTest2.txt", 126)>]
let ``Calculate Part2 Test Case`` (fileName, expected) =
    let result = calculatePart2FromFile "shiny gold" fileName
    Assert.Equal (expected, result)

[<Fact>]
let ``Real Case Part2`` () =
    let result = calculatePart2FromFile "shiny gold" "input.txt"
    Console.WriteLine (result)