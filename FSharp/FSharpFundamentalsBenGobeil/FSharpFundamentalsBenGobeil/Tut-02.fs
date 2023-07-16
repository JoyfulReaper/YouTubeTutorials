namespace FSharpBasics

// No values in namespaces - Can contain types, modules, classes


// Grouping of code elements
module Arithmetic =
    module Addition =  // Modules can be nested
       let add x y = x + y

module Other =
    open Arithmetic

    let program =
        //Arithmetic.Addition.add 5 3
        Addition.add 5 3