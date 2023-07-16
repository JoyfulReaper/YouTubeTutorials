namespace FSharpBasics

// No values in namespaces - Can contain types, modules, classes


// Grouping of code elements
module Arithmetic = 
    module Addition =  // Modules can be nested. Modules can be made private
       let add x y = x + y
       let private add' x y = x + y // Can only be used in the same module

module Other =
    open Arithmetic

    let program =
        //Arithmetic.Addition.add 5 3
        Addition.add 5 3