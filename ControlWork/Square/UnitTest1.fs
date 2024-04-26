module Square

open NUnit.Framework
open ControlWork.Square
open FsUnit


[<Test>]
let Test1 () =
    let expected = [["*"]]
    let result = createSquare 1
    Assert.AreEqual(expected, result)
    
[<Test>]
let Test2 () =
    let expected =  [[ "*"; "*"; "*"; "*" ]; [ "*"; " "; " "; "*" ]; [ "*"; " "; " "; "*" ]; [ "*"; "*"; "*"; "*" ]]
    let result = createSquare 4
    Assert.AreEqual(expected, result)