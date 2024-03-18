namespace EvenNumbers

module EvenNumbers =
    let countEvenNumbersWithFold ls =
        ls
        |> List.fold (fun acc number ->
            if (number % 2 = 0) then acc + 1 else acc) 0
    
    let countEvenNumbersWithMap ls =
        ls |> Seq.map (fun x -> abs (x + 1) % 2) |> Seq.sum
        
    let countEvenNumbersWithFilter ls =
        ls |> Seq.filter (fun x -> x % 2 = 0) |> Seq.length