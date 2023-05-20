// https://www.youtube.com/watch?v=JuIq7mU50jA

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Giraffe

module Handlers =
    let helloWorld : HttpHandler = 
        setStatusCode 202 >=> text "Hello World"

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddGiraffe() |> ignore

    let app = builder.Build()

    //app.UseGiraffe Handlers.helloWorld
    //app.UseGiraffe (HttpHandlers.sayHello "Hello From Giraffe")
    //app.UseGiraffe HttpHandlers.helloJson
    app.UseGiraffe HttpHandlers.listFiles

    app.Run()

    0 // Exit code

