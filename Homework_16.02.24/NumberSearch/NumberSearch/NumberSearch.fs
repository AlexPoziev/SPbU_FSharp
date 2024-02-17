module NumberSearch

let findFirstIndex list number =
    let rec helper ls i =
        match ls with
        | [] -> None
        | h :: _ when h = number -> Some(i)
        | _ :: t -> helper t (i + 1)
    helper list 0
    