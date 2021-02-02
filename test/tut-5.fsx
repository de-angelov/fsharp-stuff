type IAdd = 
    abstract member Add : unit -> double

// implement interface 
let someObject = {
    new IAdd with 
        member this.Add () = 7.
}


let objectIAdd = someObject :?> IAdd

type SomeClass() = class end

type SomeClass1(first, second) as self = 
    let ten = 10

    new() = SomeClass1(0., 0.)
    

    member _.Ten 
        with get() = 10
        and set (value: int) = printf "%i" value
    member this.Add (x: double, y: double) = x + y 
    member this.Add x = x + ten
    static member  AddStatic (x: int, y: int) = x + y

// use to cleanup  for classes that use  idisposable 

let someClass1 = SomeClass1()

someClass1.Ten <- 1000