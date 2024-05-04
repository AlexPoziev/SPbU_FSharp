module FibonacciTests

open NUnit.Framework
open ControlWork.Fibonacci

[<Test>]
let SumEvenFibonacci_WithOneMillion_ShouldReturnExpectedResult () =
    let expectedResult = 1089154
    Assert.AreEqual(expectedResult, sumEvenFibonacci 1000000)
