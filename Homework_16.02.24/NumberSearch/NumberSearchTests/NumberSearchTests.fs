module NumberSearchTests

open NUnit.Framework
open NumberSearch

let findFirstIndexTestData =
    [([1; 4; 5; 6], 4, Some(1))
     ([1; 4; 5; 5; 5], 5, Some(2))]
    |> List.map (fun (ls, number, expected) -> TestCaseData(ls, number, expected))

[<TestCaseSource("findFirstIndexTestData")>]
let findFirstIndex_ShouldReturnExpectedResult(ls, number, expected) =
    Assert.AreEqual(expected, findFirstIndex ls number)
    
[<Test>]
let findFirstIndex_WithListNotContainingNumber_ShouldReturnNone () =
    let number = 5
    let ls = [1; 2]
    Assert.AreEqual(None, findFirstIndex ls number)
   