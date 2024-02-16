open System

let list = [1..10]
let number = 6

let findFirstIndex (list, number) =
    let rec helper ls i =
        match ls with
        | [] -> -1
        | h :: _ when h = number -> i
        | _ :: t -> helper t (i + 1)
    helper list 0
    
let result = (list, number) |> findFirstIndex
match result with
| -1 -> Console.WriteLine("Number not found")
| _ -> Console.WriteLine(result)