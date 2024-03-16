namespace LambdaInterpreter

module Interpreter =
    type 'a Variable = 'a
    
    type 'a Term =
        | Variable of 'a Variable
        | Abstraction of 'a Variable * 'a Term
        | Application of 'a Term * 'a Term
        
    let rec getTermFV term =
        let helper term fv =
            match term with
            | Variable name -> fv |> Set.add name
            | Application (firstTerm, secondTerm) -> getTermFV firstTerm + getTermFV secondTerm
            | Abstraction (var, innerTerm) -> getTermFV innerTerm |> Set.remove var
        helper term Set.empty
        
    let isBV term variable =
         Set.contains variable (getTermFV term) |> not
        
    let incrementMax (set: Set<int>) =
        (Set.maxElement set) + 1
    
    let rec substitution innerTerm var outerTerm =
        match innerTerm with
        | Variable name when name = var -> outerTerm
        | Variable _ -> innerTerm
        | Application(firstTerm, secondTerm) ->
            Application(substitution firstTerm var outerTerm, substitution secondTerm var outerTerm)
        | Abstraction (abstractionVar, abstractionTerm) ->
            match abstractionVar with
            | name when name |> isBV outerTerm || var |> isBV abstractionTerm ->
                Abstraction(name, substitution abstractionTerm var outerTerm)
            | _ ->
                let newVar = incrementMax (getTermFV abstractionTerm + getTermFV outerTerm)
                Abstraction(newVar, substitution (substitution outerTerm abstractionVar (Variable(newVar)) ) var outerTerm)
                
    let rec reduce term =
        match term with
        | Variable _ -> term
        | Abstraction (var, innerTerm) -> Abstraction(var, reduce innerTerm)
        | Application (firstTerm, secondTerm) ->
            match firstTerm with
            | Abstraction (var, innerTerm) -> substitution innerTerm var secondTerm
            | _ -> Application(reduce firstTerm, reduce secondTerm)
