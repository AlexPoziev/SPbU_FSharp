module PowerSeriesTests

open NUnit.Framework
open PowerSeries

let correctPowerSeriesTests =
    [(0, 3, [1; 2; 4; 8])
     (0, 0, [1])
     (1, -1, [2])
     (1, 2, [2; 4; 8])]
    |> List.map (fun (n, m, ls) -> TestCaseData(n, m, ls))

[<TestCaseSource("correctPowerSeriesTests")>]
let PowerSeries_WithCorrectArguments_ShouldReturnExpectedResult(n, m, expected) =
    Assert.AreEqual(expected, match powerSeries (n,m) with | Some(x) -> x | _ -> [])
    
[<TestCase(-1, 5)>]
[<TestCase(1, -2)>]
let PowerSeries_WithIncorrectArgument_ShouldReturnNone(n, m) =
    Assert.AreEqual(None, powerSeries (n, m))