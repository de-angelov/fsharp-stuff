#load "Library.fs"
open FizzBuzz

Parser.tryParse "2"
Parser.tryParse "Tomato"

open Validator 

ValidNumber.isValidNumber 22
|> Option.map FizzBuzz.getFizzBuzzString 


