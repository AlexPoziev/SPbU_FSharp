module LambdaInterpreter.Tests

open FsUnit 
open NUnit.Framework
open Interpreter

let testData () =
    let x = 1
    let y = 2
    let z = 3
    [   
        Application(Abstraction(x, Application(Variable(x), Variable(y))), Abstraction(z, Variable(z))), Application (Abstraction (z, Variable z), Variable y)
        Application (Abstraction (z, Variable z), Variable y), Variable(y)
        Variable(y), Variable(y)
    ] |> List.map (fun (input, result) -> TestCaseData(input, result))

[<TestCaseSource(nameof testData)>]
let betaReductionTest input expected  =  
     reduce input |> should equal expected