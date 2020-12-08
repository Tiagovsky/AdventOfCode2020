module Program

open Common.Files
open System

let parseRule (rule:string) =
    let mainBag = rule.[.. rule.IndexOf(" bags contain") - 1];
    let contained = rule.[rule.IndexOf(" bags contain ") + 14 ..].Split(", ")
                    |> Array.filter (fun s -> not (s.Contains("other bags")))
                    |> Array.map (fun s -> (s.[2 .. s.IndexOf(" bag") - 1], s.[0]))

    (mainBag, contained)

let rec findBags desiredBag rules bagRule =
    let containsBag = 
        snd bagRule
        |> Array.exists (fun (b, _) -> b = desiredBag)

    let getRule name =
        rules
        |> Array.find (fun (r,_) -> r = name)

    if (containsBag) then true
    else
        snd bagRule
        |> Array.map (fun (c,_) -> getRule c)
        |> Array.exists (findBags desiredBag rules)

let calculatePart1 desiredBag rules =
    let parsedRules = rules |> Array.map parseRule

    parsedRules
    |> Array.filter (findBags desiredBag parsedRules)
    |> Array.length

let calculatePart1FromFile (desiredBag:string) filePath =
    filePath
    |> getLineValuesFromFilePath
    |> calculatePart1 desiredBag

let getRuleInRules name rules =
    rules
    |> Array.find (fun (r,_) -> r = name)

let rec countBags rule rules =
    let inline charToInt c = int c - int '0'

    let insideBags = 
        snd rule
        |> Array.map (fun (r,c) -> (r, c |> charToInt))

    let insideBagsCount = 
        insideBags
        |> Array.map snd
        |> Array.sum

    let getCountInInsideBags name =
        insideBags
        |> Array.find (fun (r, c) -> r = name)
        |> snd

    if (insideBagsCount = 0) then
        0
    else
        let insideRulesCount = 
            snd rule
            |> Array.map (fun (c,_) -> getRuleInRules c rules)
            |> Array.map (fun r -> (countBags r rules) * (getCountInInsideBags (fst r)))
            |> Array.sum

        insideBagsCount + insideRulesCount

let calculatePart2 desiredBag rules =
    let parsedRules = rules |> Array.map parseRule
    
    let initialRule = getRuleInRules desiredBag parsedRules

    parsedRules
    |> countBags initialRule

let calculatePart2FromFile (desiredBag:string) filePath =
    filePath
    |> getLineValuesFromFilePath
    |> calculatePart2 desiredBag
