module PrimeNumberGeneratorTests

open NUnit.Framework
open FsUnit
open PrimeNumbers.Generator

let testData () = 
    [   
        1, seq{2}
        3, seq{2; 3; 5}
        4, seq{2; 3; 5; 7}
    ]
    |> List.map (fun (number, expected) -> TestCaseData(number, expected))

[<TestCaseSource("testData")>]
let generatePrimeNumbersTests number expected =  
     primeNumbers |> Seq.take number |> should equal expected