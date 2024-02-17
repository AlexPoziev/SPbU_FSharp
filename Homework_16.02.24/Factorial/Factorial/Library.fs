module Factorial

let factorial number =
    let rec helper acc i =
        match i with
        | x when x < 0 -> None
        | 0 -> Some(acc)
        | x -> helper (acc * x) (i - 1)
    helper 1 number
    