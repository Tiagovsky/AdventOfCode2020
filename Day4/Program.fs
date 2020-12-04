module Program

open Common.Files
open System
open System.Text.RegularExpressions


let isPart1Valid (str:string) =
    str.Contains "byr" && str.Contains "iyr" &&
    str.Contains "eyr" && str.Contains "hgt" &&
    str.Contains "hcl" && str.Contains "ecl" &&
    str.Contains "pid"


let calculatePart1 passportArr =
    passportArr
    |> Array.filter isPart1Valid
    |> Array.length

let isRegexMatch pattern (input:string) =
    (Regex.Match (input, pattern)).Success

let isPart2Valid (str:string) =
    let properties = str.Split (Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    |> Array.map (fun s -> s.Split (' ', StringSplitOptions.RemoveEmptyEntries))
                    |> Array.concat

    let isByrValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "byr")
        |> isRegexMatch "byr:(19[2-9]\d|200[0-2])"

    let isIyrValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "iyr")
        |> isRegexMatch "iyr:(201\d|2020)"

    let isEyrValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "eyr")
        |> isRegexMatch "eyr:(202\d|2030)"

    let isHgtValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "hgt")
        |> isRegexMatch "hgt:((((1[5-8]\d)|((19)[0-3]))cm)|((59)|(6\d)|(7[0-6]))in)"

    let isHclValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "hcl")
        |> isRegexMatch "^hcl:#[0-9a-f]{6}$"

    let isEclValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "ecl")
        |> isRegexMatch "^ecl:((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth))$"

    let isPidValid = 
        properties
        |> Array.find (fun s -> s.StartsWith "pid")
        |> isRegexMatch "^pid:[0-9]{9}$"

    isByrValid && isIyrValid &&
    isEyrValid && isHgtValid &&
    isHclValid && isPidValid && 
    isEclValid

let calculatePart1FromFile filePath =
    let fileContent = readFile filePath
    
    fileContent.Split ($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
    |> calculatePart1

let calculatePart2 passportArr =
    passportArr
    |> Array.filter isPart1Valid
    |> Array.filter isPart2Valid
    |> Array.length

let calculatePart2FromFile filePath =
    let fileContent = readFile filePath
    
    fileContent.Split ($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
    |> calculatePart2


