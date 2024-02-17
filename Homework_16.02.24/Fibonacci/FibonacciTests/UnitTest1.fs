module FibonacciTests

open NUnit.Framework
open Fibonacci

[<TestCase(0, 0)>]
[<TestCase(1, 1)>]
[<TestCase(2, 1)>]  
[<TestCase(3, 2)>]
[<TestCase(10, 55)>]
let Fibonacci_WithCorrectArgument_ShouldReturnExpectedValue (number, expected) =
    Assert.AreEqual(expected, match fibonacci number with | Some(x) -> x | None -> -1)
    
let Fibonacci_WithLessThanZeroArgument_ShouldReturnNone () =
    let number = -1
    Assert.AreEqual(None, fibonacci number)