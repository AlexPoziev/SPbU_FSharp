open System

let testList =  [1..5]

let reverse list =
    let rec helper ls acc =
        match ls with
        | h :: t -> helper t (h :: acc)
        | [] -> acc
    helper list []

testList |> reverse |> List.iter Console.WriteLine