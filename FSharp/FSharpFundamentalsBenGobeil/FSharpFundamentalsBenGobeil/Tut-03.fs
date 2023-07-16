namespace FSharpBasics
open System
open System.Threading

// Unit ()
// Side effect, not deterministic, evaluates at another time

module Program =
    [<EntryPoint>]
    let main args =
        let currentTime () = // Need to call with unit ().. Causes expression to evaluate each time its called. Without the () it would only evaluate once
            DateTime.Now

        printfn "Time = %O" (currentTime())

        Thread.Sleep 2000

        currentTime()           // Correct way is using the pipe operator
        |> printfn "Time = %O"

        0