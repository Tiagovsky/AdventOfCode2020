namespace Common

module Whaat =
    let combine arr =
        let maxIndex = Array.length arr - 1
        [| for i = 0 to maxIndex do
            for j = i + 1 to maxIndex do
                yield (arr.[i],arr.[j]) |]

