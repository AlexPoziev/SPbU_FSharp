module ParseTreeTests

open NUnit.Framework
open FsUnit
open ParseTree.ParseTreeCalculation

let testData () = 
    [
        Operation(Minus, Operation(Plus, Operand(1), Operand(2)), Operation(Minus, Operand(1), Operand(2))), 4
        Operand(5), 5
    ]
    |> List.map (fun (expression, expected) -> TestCaseData(expression, expected))
    
[<TestCaseSource("testData")>]
let ``calculate with correct arguments should return expected result`` (expression, expected) =
    calculate expression |> should equal expected