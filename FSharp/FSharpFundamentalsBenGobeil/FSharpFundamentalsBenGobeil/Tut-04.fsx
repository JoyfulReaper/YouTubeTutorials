// Product Types
// Record Types, Tuple, Anonymous Record

type Day = 
    { DayOfTheMonth: int; 
      Month: int}

type Person = { Name: string; Age: int}

// Type annotation
let ben: Person = {Name = "Ben"; Age = 26}
ben.Name

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