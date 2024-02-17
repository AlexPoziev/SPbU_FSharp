module Reverse

let reverse list =
    let rec helper ls acc =
        match ls with
        | [] -> acc
        | h :: t -> helper t (h :: acc)
    helper list []