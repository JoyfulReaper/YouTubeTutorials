// Product Types
// Record Types, Tuple, Anonymous Record

type Day = 
    { DayOfTheMonth: int; 
      Month: int}

type Person = { Name: string; Age: int}

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

type Rectangle = { Base: double; Height: double}

type Shape =
    //| Rectangle of height:double * _base:double  // Of keyword is like constructor. Can have labels
    // Union Case - Not a type, its a constructor -> Will create a shape Object. Constructor of Rectangle case takes a Rectangle type
    | Rectangle of Rectangle
    | Triangle of height:double * __base:double
    | Circle of radius:double
    | Dot


// When writing a function that takes or acts on shapes, should group together in shape module
module Shape =
    let area shape =
        ()