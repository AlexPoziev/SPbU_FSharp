module Square

open NUnit.Framework
open ControlWork.Square
open FsUnit


[<Test>]
let CreateSquare_WithLengthOne_ShouldReturnOneStar () =
    let expected = [["*"]]
    let result = createSquare 1
    Assert.AreEqual(expected, result)
    
[<Test>]
let CreateSquare_WithLengthFour_ShouldReturnExpectedResult () =
    let expected =  [[ "*"; "*"; "*"; "*" ]; [ "*"; " "; " "; "*" ]; [ "*"; " "; " "; "*" ]; [ "*"; "*"; "*"; "*" ]]
    let result = createSquare 4
    Assert.AreEqual(expected, result)