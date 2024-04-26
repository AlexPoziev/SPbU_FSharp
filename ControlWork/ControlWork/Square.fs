module ControlWork.Square 
    let createSquare n =
        let createRow i isEdgeRow =
            Array.init n (fun j ->
                match (i, j) with
                | 1, _ -> "*"
                | _, 1 -> "*"
                | n, _ -> "*"
                | _, n -> "*"
                | _ -> " ")
        Array.init n (fun i ->
            if i = 0 || i = n - 1 then
                createRow (i + 1) true
            else
                createRow (i + 1) false)

    let printSquare square =
        square |> Array.iter (fun row -> printfn "%s" (String.concat "" row))
