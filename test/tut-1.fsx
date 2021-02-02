let myOne = 1

let myDouble: double = 1.
let hello = "string"

let mutable isTrue = false
isTrue <- true

let add (x: int) (y: int) = x + y
let add5 x = x + 5

let add' = fun x y -> x + y
let add'' x = fun y -> x + y


let add5comlex x = 
    let five = 5
    x + five

let opperation number = (2. * (number * 3.) ) ** 2.

let add3 number = number + 3 

let add3' = (+) 3. 
let times2 = (*) 2. 
(* comment *)
let pow2 x = ( ** ) 2. x
let pow2' x =  x ** 2.

let operation' number = 
    number 
    |> add3'
    |> pow2'

let operation'' 
    = add3' 
    >> times2 
    >> pow2'


// define new 

let (>>) f g = fun x -> 
    x 
    |> f 
    |> g