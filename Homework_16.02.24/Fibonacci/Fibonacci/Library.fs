module Fibonacci

let fibonacci number =
    match number with
    | x when x < 0 -> None
    | _ ->
            let rec helper (first, second) i =
                match i with
                | i when i = number -> Some(first)
                | _ -> helper (second, first + second) (i + 1)
            helper (0, 1) 0
            