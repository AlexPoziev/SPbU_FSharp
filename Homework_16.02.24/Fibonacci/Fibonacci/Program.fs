open System

let intInput = Console.ReadLine() |> int

let fibonacci number =
    match number with
    | x when x = 0 || x = 1 -> x
    | x when x < 0 -> -1
    | _ ->
        let rec calculate (first, second) i =
            if i = (number - 1) then second
            else calculate(second, first + second) (i + 1)
        calculate (1, 1) 1
    
let result = intInput |> fibonacci
if result = -1 then printf "Number is less than 0"
else printf $"Fibonacci number: %d{result}"