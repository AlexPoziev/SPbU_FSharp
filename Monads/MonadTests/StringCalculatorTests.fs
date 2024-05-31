module StringCalculatorTests

open NUnit.Framework
open FsUnit
open StringWorkflow

[<Test>]
let ``Correct data case test`` () =
    let calculator = StringCalculator() {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    calculator |> should equal (Some(3))

[<Test>]
let ``Incorrect data case test`` () =
    let calculator = StringCalculator() {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    }
    calculator |> should equal None