module FactorialTests

open NUnit.Framework
open Factorial

[<TestCase(0, 1)>]
[<TestCase(1, 1)>]
[<TestCase(5, 120)>]
let Factorial_WithMoreThanZeroArgument_ReturnsExpectedValue (number, expected) =
    Assert.AreEqual(expected, match factorial number with | Some(x) -> x | None -> -1)

[<Test>]
let Factorial_WithLessThanZeroArgument_ReturnsNone () =
    let argument = -2
    let expected = None
    Assert.AreEqual(expected, factorial argument)   