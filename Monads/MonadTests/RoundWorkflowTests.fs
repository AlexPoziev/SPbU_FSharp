module RoundingWorflowTests

open NUnit.Framework
open FsUnit
open RoundingWorkflow

[<Test>]
let ShouldReturnRoundedToThreeSymbolsAfterComma_WhenAccurateEqualThree () =
    let flow = RoundWorkflow 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    flow |> should equal 0.048

[<Test>]
let ShouldReturnRoundedToZeroSymbolAfterComma_WhenAccurateEqualZero () =
    let flow = RoundWorkflow 0 {
        let! a = 1.0 / 3.125
        let! b = 5
        return a * b + 1.01
    }
    flow |> should equal 1