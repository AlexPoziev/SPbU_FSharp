namespace ParseTree

module ParseTreeCalculation =
    type Operator =
        | Plus
        | Minus
        | Division
        | Multiplication
        
    type 'a ParseTree =
        | Operand of 'a
        | Operation of Operator * 'a ParseTree * 'a ParseTree
        
    let calculateIntOperator (operator: Operator, l: int, r: int) =
        match operator with
        | Plus -> l + r
        | Minus -> l - r
        | Multiplication -> l * r
        | Division -> l / r
    
    let rec calculate parseTree =
        match parseTree with
        | Operand value -> value
        | Operation (op, l, r) -> calculateIntOperator (op, calculate l, calculate r) 