namespace FSharpBasics

module Program = 
    [<EntryPoint>]
    let main args = 
        let age = 26
        printf "Hello world  and i %i" age
        let name = Console.ReadLine()
        print "Hi %s" name

        let currentTime () = 
            DateTime.Now
            
        (currentTime()) |> printFn "Time = %O" 





        0
