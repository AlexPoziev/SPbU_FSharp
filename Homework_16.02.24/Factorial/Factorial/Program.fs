open System

let intInput = Console.ReadLine() |> int

let factorial number =
    match number with
    | 0 -> 1
    | x when x > 0 -> [1..x] |> Seq.fold (*) 1
    | _ -> -1
    
let result = intInput |> factorial

if result < 0 then printf $"Number %d{intInput} is negative"
else printf $"Factorial of %d{intInput} is %d{result}"