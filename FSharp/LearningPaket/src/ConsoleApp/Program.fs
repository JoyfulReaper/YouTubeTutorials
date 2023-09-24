open System
open FSharpPlus


let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#"
    let message = String.replace "from" "to" message
    printfn "Hello world %s" message
    0