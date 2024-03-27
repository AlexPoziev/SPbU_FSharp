module BracketsBalanceTests

open NUnit.Framework
open BracketsBalance.BracketsBalance
open FsUnit

let testData =
    [
      "()", true
      "(](", false
      "(]", false
      "adfdasg", true
      "([]{}){[]}", true
    ]
    |> List.map (fun (data, expected) -> TestCaseData(data, expected))

[<TestCaseSource("testData")>]
let TestBraceChecker str expected =
    isBalanced str |> should equal expected