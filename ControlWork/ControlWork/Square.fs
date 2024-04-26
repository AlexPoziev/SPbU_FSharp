module ControlWork.Square 
    let createSquare n =
        let createRow i =
            List.init n (fun j ->
                match (i, j) with
                | 0, _ -> "*"
                | _, 0 -> "*"
                | t, _ when t = n - 1 -> "*"
                | _, t when t = n - 1 -> "*"
                | _ -> " ")
        List.init n createRow


    let printSquare n =
        createSquare n |> List.iter (fun row -> printfn "%s" (String.concat "" row))
