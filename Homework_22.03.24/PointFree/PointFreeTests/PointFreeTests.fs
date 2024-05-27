module PointFreeTests

open NUnit.Framework
open FsCheck
open PointFree.PointFree

[<Test>]
let ``Is function works as expected`` () =
    let testList = [1; 2; 3; 4; 5; 6]
    let expected = [2; 4; 6; 8; 10; 12]
    Assert.That(funcInitial 2 testList, Is.EqualTo(expected))
   

[<Test>]
let ``Are the functions equivalent`` () =
    let isCorrect x ls = funcInitial x ls = funcLast x ls
    Check.QuickThrowOnFailure isCorrect