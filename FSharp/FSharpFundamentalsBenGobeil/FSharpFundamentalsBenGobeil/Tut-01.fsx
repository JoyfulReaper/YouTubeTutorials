//https://www.youtube.com/watch?v=SvOInBxPL30

// Associate a value to a name
let myOne = 1
let myTwo = 2

let hello = "hello"

let letterA = 'a'

let isEnabled = false // Equality


// int -> int -> int
let add x y = x + y
let add' = fun x y -> x + y
let add'' x = fun y -> x + y // Currying / Baking in - Used for dependency injection

// int -> int
let add5 x =
    let five = 5
    x + five

let add5' x = add 5 x
let add5'' = add 5  // Point free style

add5' 6


// (2 * (number + 3)) ^ 2
let operation number = (2. * (number + 3.)) ** 2.

let add3 number = number + 3 // Infix Notation - In between the parameters

// 3 + number - Even though the 3 is on the right. Doesn't matter for +, but you know...
let add3' number = (+) number 3. // Prefix Notation - 
let add3'' = (+) 3.

let times2 = (*) 2.

// 2 ^ x - Not what we want
let pow2' = ( **) 2.

let pow2 number = number ** 2.

let operation' number =
    pow2 (times2 (add3' number))

let operation'' number =
    number
    |> add3'
    |> times2
    |> pow2

let (>>) f g =
    fun x ->
        x
        |> f
        |> g
        //g(f x)

let operation''' =
    add3' 
    >> times2
    >> pow2

operation 1.
operation' 1.
operation'' 1.
operation''' 1.