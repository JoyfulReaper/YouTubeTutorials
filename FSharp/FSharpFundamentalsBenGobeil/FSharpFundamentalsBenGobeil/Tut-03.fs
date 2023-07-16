namespace FSharpBasics
open System
open System.Threading

// Unit ()
// Side effect, not deterministic, evaluates at another time

module Program =
    [<EntryPoint>]
    let main args =
        let age = 26
        // int -> unit Function takes an int, produces a side effect (writing to console) and returns unit
        printfn "Hello world and I am %i" age

        printf "Hi, what is your name? "
        let name = Console.ReadLine()
        printfn "Hi %s" name

        let notCurrentTime = // Evaluated only once
            DateTime.Now

        let currentTime () = // Need to call with unit ().. Causes expression to evaluate each time its called. Without the () it would only evaluate once
            DateTime.Now

        printfn "Time = %O" notCurrentTime
        printfn "Time = %O" (currentTime())

        Thread.Sleep 2000

        notCurrentTime
        |> printfn "Time = %O"

        currentTime()           // Correct way is using the pipe operator
        |> printfn "Time = %O"

        0