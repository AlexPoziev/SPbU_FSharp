module EvenNumbersTests

open NUnit.Framework
open EvenNumbers.EvenNumbers
open FsUnit
open FsCheck

let testData () = 
    [
        [1..5], 2
        [1..11], 5
        [-4 .. 1], 3
        [], 0
    ]
    |> List.map (fun (ls, expected) -> TestCaseData(ls, expected))

[<TestCaseSource("testData")>]
let ``countEventNumbers based on map should return expected result`` ls expected =
    countEvenNumbersWithMap ls |> should equal expected

[<Test>]
let ``countEventNumbers based on map and filter return same results`` () =
    let areMapAndFilterBasedFunctionsEquivalent (ls : List<int>) =
        countEvenNumbersWithMap ls = countEvenNumbersWithFilter ls

    Check.QuickThrowOnFailure areMapAndFilterBasedFunctionsEquivalent

[<Test>]
let ``countEventNumbers based on map and fold return same results`` () =
    let areMapAndFoldBasedFunctionsEquivalent (ls : List<int>) =
        countEvenNumbersWithMap ls = countEvenNumbersWithFold ls

    Check.QuickThrowOnFailure areMapAndFoldBasedFunctionsEquivalent