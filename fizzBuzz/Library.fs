namespace FizzBuzz
open System

[<RequireQualifiedAccess>]
module Option = 
    let fromTryTuple = function 
        | false, _ -> None
        | true, x -> Some x 

[<RequireQualifiedAccess>]
module Result = 
    let fromOption errorValue = function 
        | Some x -> Ok x 
        | None -> Error errorValue

module Parser =
    let tryParse (input : string) = 
        Int32.TryParse input
        |> Option.fromTryTuple

module Validator =
    type ValidNumber = private ValidNumber of int
    
    module ValidNumber = 
        let value (ValidNumber number) = number

        let isValidNumber number = 
            match 1 <= number && number <= 4000 with
            | false -> None 
            | true -> Some <| ValidNumber number

module FizzBuzz = 
    open Validator

    let getFizzBuzzString (number: ValidNumber) =
        [1 .. ValidNumber.value number] 
        |> List.map (
            fun (n: int) -> (n, n % 3, n % 5) 
            >> function
                | (_, 0, 0) -> "FizzBuzz"
                | (_, 0, _) -> "Fizz"
                | (_, _ , 0) -> "Buzz"
                | (n, _, _) -> string n
        )
        |> String.concat "\n"
 
module Domain = 
    open Validator

    type ParseNumber = string -> int option 
    type ValidateNumber = int -> ValidNumber option
    type GetFizzBuzzString = ValidNumber -> string

    type ParserError = NotANumber of string
    type ValidatorError = InvalidNumber of int

    type DomainError = 
        | ParserError of ParserError
        | ValidatorError of ValidatorError

    type ExecuteFizzBuzzWorkflow = string -> Result<string, DomainError>

    let execute 
            (parseNumber: ParseNumber) 
            (validateNumber: ValidateNumber) 
            (getFizzBuzzString: GetFizzBuzzString)
            : ExecuteFizzBuzzWorkflow = 
                let parseNumber input = 
                     input 
                    |> parseNumber 
                    |> Result.fromOption (NotANumber input)
                    |> Result.mapError ParserError
            
                let validateNumber number = 
                    number 
                    |> validateNumber  
                    |> Result.fromOption (InvalidNumber number)
                    |> Result.mapError ValidatorError

                fun input -> 
                    input 
                    |> parseNumber
                    |> Result.bind validateNumber
                    |> Result.map getFizzBuzzString


module Application = 
    open Domain

    type Input = unit -> string
    type Output = string -> unit

    let execute = 
        Domain.execute
            Parser.tryParse
            Validator.ValidNumber.isValidNumber
            FizzBuzz.getFizzBuzzString

    let application (input: Input) (output: Output) =
        fun () ->
            output "Please enter a number between 1 and 4000:"
            
            input () 
            |> execute
            |> function 
                | Ok s -> 
                    sprintf "Here is the output\n%s" s
                    |> output
                | Error (ParserError (NotANumber s)) -> 
                    sprintf "%s is not an integer" s
                    |> output
                | Error (ValidatorError (InvalidNumber n)) ->
                    sprintf "You entered %i. Please enter a valid integr between 1 and 4000" n
                    |> output