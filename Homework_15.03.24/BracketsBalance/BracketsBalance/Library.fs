namespace BracketsBalance

module BracketsBalance =
    let brackets = [
        ('(', ')');
        ('{', '}');
        ('[', ']')
    ]
    
    let openBrackets =
        brackets |> List.map fst
        
    let closeBrackets =
        brackets |> List.map snd
        
    let sameCloseBracket bracket =
        snd (List.head (brackets |> List.filter (fun x -> fst x = bracket))) 
        
    let isBalanced (str: string) : bool =
        let rec helper currentIndex ls =
            if
                (currentIndex >= str.Length) then List.isEmpty ls
            else
                let currentChar = str[currentIndex]
                match currentChar with
                | op when (openBrackets |> List.contains op) -> helper (currentIndex + 1) (currentChar :: ls)
                | cl when closeBrackets |> List.contains cl ->
                    match ls with
                    | h :: t when cl = (h |> sameCloseBracket) -> helper (currentIndex + 1) t
                    | _ -> false
                | _ -> helper (currentIndex + 1) ls
        helper 0 List.Empty
            
            