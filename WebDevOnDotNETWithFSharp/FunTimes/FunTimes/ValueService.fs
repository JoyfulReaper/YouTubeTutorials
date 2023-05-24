namespace ValueService

type IValuesService =
    abstract member GetAllValues: unit -> string[]
    abstract member GetValue: int -> string


type ValuesService() =
    let valuesDb = [| "value1"; "value2" |]

    interface IValuesService with
        member __.GetAllValues() = valuesDb
        member __.GetValue(index: int) =
            let result = valuesDb |> Array.tryItem index
            match result with
            | Some value -> value
            | None -> "Oh nooooooooo...."