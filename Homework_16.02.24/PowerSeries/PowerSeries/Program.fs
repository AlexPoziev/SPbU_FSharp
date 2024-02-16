open System
let n = Console.ReadLine() |> int
let m = Console.ReadLine() |> int

let powerSeries n m =
    let twoInNthPower = pown 2 n
    let rec helper acc element i =
        match i with
        | _ when i > m + n -> acc
        | _ when i >= n -> helper (acc @ [element * 2]) (element * 2) (i + 1)
        | _ -> []
    if (n < 0 || n + m < 0) then []
    else helper [twoInNthPower] twoInNthPower (n + 1)
        
let result = powerSeries n m
match result with
| [] -> Console.WriteLine("Incorrect arguments")
| _ -> result |> List.iter Console.WriteLine
