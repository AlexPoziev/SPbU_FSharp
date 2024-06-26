module TreeMapTests

open NUnit.Framework
open FsUnit
open Tree.TreeMap

let multiply = fun x -> x * 2
let increment = fun x -> x + 1

[<Test>]
let ``treeMap with not empty tree with multiply by 2 function should return expected value`` () =
    let tree = Tree(1, Tree(2, Tree(1, Empty, Empty), Empty), Tree(10, Empty, Tree(15, Empty, Empty)))
    let expected = Tree(2, Tree(4, Tree(2, Empty, Empty), Empty), Tree(20, Empty, Tree(30, Empty, Empty)))
    treeMap tree multiply |> should equal expected
    
[<Test>]
let ``treeMap with not empty tree with increment function should return expected value`` () =
    let tree = Tree(1, Empty, Tree(10, Empty, Tree(15, Empty, Empty)))
    let expected = Tree(2, Empty, Tree(11, Empty, Tree(16, Empty, Empty)))
    treeMap tree increment |> should equal expected
    
[<Test>]
let ``treeMap with empty tree should return expected value`` () =
    let tree = Empty:Tree<int>
    let expected = Empty:Tree<int>
    treeMap tree multiply |> should equal expected