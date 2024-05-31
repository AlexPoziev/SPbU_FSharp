module StringWorkflow

open System

type StringCalculator() =
    member this.Bind(str : string, f) =
            match Int32.TryParse(str) with
            | false, _ -> None
            | true, value -> f value

    member this.Return(v) = Some(v)