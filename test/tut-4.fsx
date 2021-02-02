(* PRODUCT TYPE *)
// RECORD
type DayOfTheYear =  { Month: int; Day: int}
type Person = 
    {
        Name: string
        Age: int 
    } with 
        static member (+) ({Name= n1; Age = a1 }, {Name = n2; Age = a2})
            = {Name = n1 + n2; Age = a1 + a2 }

type Duo = { Person1: Person; Person2: Person }

let den = 
    { Name = "Den"; Age= 32 }

let name = den.Name;

let incrementAge person = 
    {
        person with Age = person.Age + 1
    }
// TUPLE

type Duo' = Person * Person

// ANON RECORD

let duo = {| Person1= den ; Person2= den |}

let trio = {| duo with Person3 = den |}


// wrapper type
type OrderId = OrderId of int
let incrementOrderId (OrderId id) = 
    id + 1
    |> OrderId
    //  OrderId <| id + 1

// Sum Types
type Suit = 
    | Hearts 
    | Clubs
    | Spades
    | Diamonds

 type Rectangle = { Base: double; Height: double }

type Shape = 
    | Rectangle of double * double
    | Rectangle' of height: double * _base: double
    | Rectangle'' of Rectangle 
    | Circle of radius: double
    | Dot


let yesOrNo bool = if bool then "YES" else "NO"

let yesOrNo' bool = 
    match bool with
    | true -> "Yes"
    | false -> "No"

let yesOrNo'' bool = function
    | true -> "Yes"
    | false -> "No"

let isOdd = function
    | x when x % 2 = 0 -> true 
    | _ -> false
   

let someCircle = Circle 1.;

module Shape = 
    let area shape = 
        match shape with 
        | Rectangle (h, b) -> h * b
        | Rectangle'' rect ->  rect.Height * rect.Base
        // | Rectangle'' {Base = b; Height = h } ->  b * h
        | _ -> 0.

let translateFizzBuzz = function 
    | "Fizz" -> string 3
    | "Buzz" -> string 5
    | "FizzBuzz" -> string 15
    | x -> x


let inline add x y = x + y

let add' x y = x + y


// Arrays

let array = [| 1;2;3|]
array.[1] <- 12

// List
[1;2;3;4;5;6;7;8;9;10;12]


// recursion 

let rec printEveryItem = function
    | x :: xs ->
    printfn "%O" x
    printEveryItem  xs
    | [] -> ()
