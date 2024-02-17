module ReverseTests

open NUnit.Framework
open Reverse

let reverseTestData =
    [([1; 2; 3], [3; 2; 1])
     ([], [])
     ([1], [1])]
    |> List.map(fun (ls, expected) -> TestCaseData(ls, expected))

[<TestCaseSource("reverseTestData")>]
let Reverse_ShouldReturn (list, expected) =
    Assert.AreEqual(expected, reverse list)