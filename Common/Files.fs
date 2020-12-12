namespace Common

module Files =
    open System.IO

    let explode (s:string) =
            [|for c in s -> c|]

    let readLines (filePath:string) = seq {
            use sr = new StreamReader (filePath)
            while not sr.EndOfStream do
                yield sr.ReadLine()
            }

    let getLineValuesFromFilePath filePath =
        [| for i in readLines filePath do
                yield i |]

    let readFile (filePath:string) =
        use sr = new StreamReader (filePath)
        sr.ReadToEnd()

    let combine arr =
        let maxIndex = Array.length arr - 1
        [| for i = 0 to maxIndex do
            for j = i + 1 to maxIndex do
                yield (arr.[i],arr.[j]) |]
