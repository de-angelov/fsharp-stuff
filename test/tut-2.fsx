namespace FSharpBasics
// no  values  (let bindings in namespaces)
module Arithmetic = 
    module private Nested = 
        let add x y = x + y 

module Other = 
    open Arithmetic.Nested 
    let private program = add 5 2
    let public program' = Arithmetic.Nested.add 5 3
    let public program' = Arithmetic.Nested.add 5 3
