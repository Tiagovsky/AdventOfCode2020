module Program

open Common.Files

type Password = {
    RequiredLetter : char
    FirstValue : int
    SecondValue : int
    Value : string
}

let isPasswordPart1Valid password =
    let isCorrectNumberOfChars charCount =
        charCount >= password.FirstValue && charCount <= password.SecondValue

    password.Value
    |> explode
    |> Array.where (fun c -> c = password.RequiredLetter)
    |> Array.length
    |> isCorrectNumberOfChars

let isPasswordPart2Valid password =

    let requiredLetter = password.RequiredLetter
    let firstPosition = password.FirstValue - 1
    let secondPosition = password.SecondValue - 1
    let value = password.Value

    value.[firstPosition] = requiredLetter && value.[secondPosition] <> requiredLetter
    || value.[firstPosition] <> requiredLetter && value.[secondPosition] = requiredLetter


let getPasswordFromString (str:string) = 
    let minCount = str.[0 .. str.IndexOf '-' - 1] |> int
    let maxCount = str.[str.IndexOf '-' + 1 .. str.IndexOf ' ' - 1] |> int
    let requiredLetter = str.[str.IndexOf ' ' + 1 .. str.IndexOf ':' - 1] |> char
    let value = str.[str.IndexOf ": " + 2 .. str.Length - 1] |> string
    { RequiredLetter = requiredLetter; FirstValue = minCount; SecondValue = maxCount; Value = value}


let calculatePart1FromFile filePath =
    getLineValuesFromFilePath filePath
    |> Array.map getPasswordFromString
    |> Array.where isPasswordPart1Valid
    |> Array.length

let calculatePart2FromFile filePath =
    getLineValuesFromFilePath filePath
    |> Array.map getPasswordFromString
    |> Array.where isPasswordPart2Valid
    |> Array.length