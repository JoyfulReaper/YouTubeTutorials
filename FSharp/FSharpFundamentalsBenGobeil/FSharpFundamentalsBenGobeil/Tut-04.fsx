// Product Types
// Record Types, Tuple, Anonymous Record

open System

type Day = 
    { DayOfTheMonth: int; 
      Month: int}

type Person =
    { Name: string; Age: int}
    with
        static member (+) ({Name = n1; Age = a1}, {Name = n2; Age = a2}) =
            {Name = n1 + n2; Age = a1 + a2}

// Type annotation
let ben: Person = {Name = "Ben"; Age = 26}
let ben2 = {Name = "Ben"; Age = 26}
ben.Name
ben.Age
ben

ben = ben2 // Value equality

let incrementAge person =
    { person with Age = person.Age + 1 }

incrementAge ben

type Duo = { Person1: Person; Person2: Person }

let alex = { Name = "Alex"; Age = 28}
let brothers = { Person1 = ben; Person2 = alex}
brothers

// Tuple type
type Dou' = Person * Person



let doSomething: Dou' =
    let a = { Name = "Example"; Age = 14}
    let b = { Name = "Person"; Age = 41}
    (a, b)

(ben, alex)

// Anonymous Record - Does not support pattern matching
let duo = 
    {|Person1 = ben; Person = alex|}

let trio = {|duo with Person3 = ben|}

// Sum Types - Sum Types

// Disciminated Union
type Suit =
    | Hearts
    | Clubs
    | Spades
    | Diamonds

let yesOrNo bool =
    if bool then "Yes" else "No"

// Match expression
let yesOrNo' bool =
    match bool with
    | true -> "Yes"
    | false -> "No"

// Point free version
let yesOrNo'' = function
    | true -> "Yes"
    | false -> "No"


let isEven = function
    | x when x % 2 = 0 -> true
    | _ -> false

let isOne = function
    | 1 -> true
    | _ -> false

let isOne' number =
    number = 1

let isOne''  =
    (=) 1


let translateFizzBuzz = function
    | "Fizz" -> string 3
    | "Buzz" -> string 5
    | "FizzBuzz" -> string 15
    | x -> x

let translateFizzBuzz' = function
    | "Fizz" -> Some 3
    | "Buzz" -> Some 5
    | "FizzBuzz" -> Some 15
    | _ -> None

let hasValue = function
    | Some _ -> true
    | None -> false

translateFizzBuzz "Fizz"
translateFizzBuzz "Buzz"
translateFizzBuzz "FizzBuzz"
translateFizzBuzz "Tomato"

type NormalRectangle = { Base: double; Height: double}

// This works with Single Case Pattern matches
// Record Types
// Tuples
// Single Case DU

type OrderId = OrderId of int

// Deconstruction
let incrementOrderId (OrderId id) =
    OrderId <| id + 1  //Apply expression on the right to the left

let incrementOrderId' =
    fun (OrderId id) ->
        OrderId <| id + 1

let area { Base = b; Height = h} =
    b * h

let area' (b,h) = b * h

type Rectangle = 
    | Normal of NormalRectangle
    | Square of side:double

module Rectangle =
    let area = function
        | Normal { Base = b; Height = h} -> b * h
        | Square s -> s ** 2.

type Shape =
    //| Rectangle of height:double * _base:double  // Of keyword is like constructor. Can have labels
    // Union Case - Not a type, its a constructor -> Will create a shape Object. Constructor of Rectangle case takes a Rectangle type
    | Rectangle of Rectangle
    | Triangle of height:double * __base:double
    | Circle of radius:double
    | Dot

let circle = Circle 1.
let triangle = Triangle (2.,4.)


// When writing a function that takes or acts on shapes, should group together in shape module
module Shape =

    let area shape =
        match shape with
        | Rectangle rect -> Rectangle.area rect
        | Triangle (h,b) -> h * b / 2.
        | Circle r -> r ** 2. * Math.PI
        | Dot -> 1

    let area' shape = function
        | Rectangle rect -> Rectangle.area rect
        | Triangle (h,b) -> h * b /2.
        | Circle r -> r ** 2. * Math.PI
        | Dot -> 1

    (*
    let area shape =
        match shape with
        | Rectangle rect -> rect.Base * rect.Height
        | Triangle (h,b) -> h * b / 2.
        | Circle r -> r ** 2. * Math.PI
        | Dot -> 1

    let area' shape =
        match shape with
        | Rectangle {Base = b; Height = h} -> h * b
        | Triangle (h,b) -> h * b / 2.
        | Circle r -> r ** 2. * Math.PI
        | Dot -> 1

    let area'' shape = function
        | Rectangle {Base = b; Height = h} -> h * b
        | Triangle (h,b) -> h * b /2.
        | Circle r -> r ** 2. * Math.PI
        | Dot -> 1
    *)

Shape.area circle
Shape.area triangle

type Option<'a> =
    | Some of 'a
    | None


// To access staticly resolved type parameters need to use inline keyword
let inline add x y = x + y
let add' x y = x + y


// Inlined no method call
add 3 5

// Method call
add' 3 5

ben + alex


// Collections - Ordered collections:
// Arrays - Fixed size mutable collection - Chunk of memory
[|1;2;3;4;5;6;7;8;9|]
[|
    1
    2
    3
    4
|]

let arr = [|1..10|]
arr[0] <- 5

// List - Linked List, Immutable
[1;2;3;4;5;6]
[
    1
    2
    3
    4
]
[1 .. 10]
[1 .. 2 .. 10]
[1. .. 0.1 .. 10.]
['a' .. 'z']

// list
(*
type LinkedList<'a> =
    | ([])
    | (::) of head: 'a * tail: LinkedList<'a>
*)
let empty = []

// x head of list
// xs tail of list
let addToList x xs =
    x::xs // append x to front of list

let sampleList = [2;3;4]
addToList 1 sampleList

let getFirstItem = function
    | x::_ -> Some x
    | _ -> None

let getFirstItem' list =
    List.head

let x: int = List.head []

let rec printEveryItem = function
    | x :: xs -> 
        printfn "%O" x
        printEveryItem xs
    | [] -> ()

let rec doWithEveryItem f = function
    | x :: xs -> 
        f x
        doWithEveryItem f xs
    | [] -> ()

[1;2;3;4;5] |> printEveryItem

// List.iter
let printEveryItem' list =
    doWithEveryItem (printf "%O") list

let printEveryItem'' list =
    list
    |> List.iter (printfn "%O")

let stringifyList list =
    list 
    |> List.map string

[1 .. 10]
|> stringifyList

// Map is like select

let x = Some 42 |> Option.map string
printfn "%s" x.Value

[1 .. 10] // sum

// Fold is like aggergate

let sum list =
    list
    |> List.fold (fun acc currentItem -> acc + currentItem) 0

let sum' list =
    list
    |> List.fold (+) 0

[1 .. 3] |> sum

// Fold with constraints: Accumalator needs to be the same type as type of every item in the list
// has to have 0 for an identity value
let reduce list =
    list
    |> List.reduce (+)

let inline sum'' list =
    List.sum list

// BIND
let divideInt d n=
    match n % d with
    | 0 -> Some <| n / d
    | _ -> None

let divideBy2 = 
    divideInt 2

let bind f = function
    | Some x -> f x
    | None -> None

24
|> divideBy2
|> Option.bind divideBy2
|> Option.bind divideBy2
// |> Option.bind divideBy2

24
|> divideBy2
|> bind divideBy2

// Exceptions
exception CannotConnectException of System.Uri // No inner exceptions, no exception message with this style

let handle f =
    try
        f ()
    with
    | CannotConnectException uri -> ()
    | :? System.ArgumentException as e -> printfn "%s" e.Message

raise (CannotConnectException (Uri("https://google.com")))

type WithdrawErrors =
    | InsufficentFunds of double
    | WrongPIN

let result = Error (InsufficentFunds 10.0)

