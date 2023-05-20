module HttpHandlers

open Giraffe
open Microsoft.AspNetCore.Http
open Microsoft.Net.Http.Headers
open System.IO
open System.Globalization

let sayHello (text: string) (next:HttpFunc) (ctx:HttpContext) =
    task {
        let bytes = System.Text.Encoding.UTF8.GetBytes text
        ctx.SetContentType "text/plain; charset=utf-8"
        ctx.SetHttpHeader (HeaderNames.ContentLength, bytes.Length)
        ctx.Response.StatusCode <- 202

        do! ctx.Response.Body.WriteAsync(bytes, 0, bytes.Length)

        return! next ctx
    }

////////////// Built in Text, XML, JSON

let hello : HttpHandler = text "Hello, World"
let helloXml : HttpHandler = xml "Hello, World"
let helloJson : HttpHandler = json  {| Message = "Hello World" |} // Anonymous Record

///////////// 

let listFiles: (HttpFunc -> HttpContext -> HttpFuncResult) =
    let options = EnumerationOptions(RecurseSubdirectories = true)
    let files = Directory.EnumerateFiles(".", "*", options) |> Seq.toArray
    json
        {| Message = "Goodbye!"
           NumberOfFiles = files.Length 
           Files = files |}


// Composing handlers
let cultureHandler next (ctx: HttpContext) =
    let cultureQuery = ctx.Request.Query.["culture"]
    if(cultureQuery.Count = 1) then
        let culture = CultureInfo cultureQuery.[0]
        CultureInfo.CurrentCulture <- culture
        CultureInfo.CurrentUICulture <- culture
    next ctx

let reportCulture next ctx =
    text $"Current culture is {CultureInfo.CurrentUICulture}" next ctx

let setAndReport : HttpHandler = cultureHandler >=> reportCulture

/// Routing
let basicRoute : HttpHandler =
    route "/hello" >=> GET >=> text "Hello, World"

let isFSharpCool isItCool =
    if isItCool then text "F# is damn cool!"
    else
        text "Try again ;)"

let fsharpRoute : HttpHandler = routef "/isFSharpCool/%b" isFSharpCool

//////

let webApp : HttpHandler =
   choose [
        route "/hello" >=> hello
        route "/xml" >=> helloXml
        route "/json" >=> helloJson
        routef "/isFSharpCool/%b" isFSharpCool
        route "/setAndReport" >=> setAndReport
        route "/listFiles" >=> listFiles
        route "/culture" >=> setAndReport
        //route "/view" >=> htmlView IsaacViewEngine.createTable
    ]