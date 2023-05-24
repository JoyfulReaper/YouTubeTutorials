namespace FunTimes.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open ValueService

[<ApiController>]
[<Route("[controller]")>]
type ValuesController (logger : ILogger<ValuesController>, service: IValuesService) =
    inherit ControllerBase()


    [<HttpGet>]
    member this.Get() =
        let values = service.GetAllValues()
        ActionResult<string[]>(values)

    [<HttpGet("{id}")>]
    member this.Get(id: int) =
        let value = service.GetValue(id)
        ActionResult<string>(value)

    [<HttpPost>]
    member this.Post([<FromBody>] value : string) =
        ()

