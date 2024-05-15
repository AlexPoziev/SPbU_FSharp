namespace Lazy

type SingleThreadedLazy<'a>(supplier: unit -> 'a) =
    let mutable value = None

    interface ILazy<'a> with
        member this.Get() =
            match value with
            | Some v -> v
            | None ->
                let computedValue = supplier()
                value <- Some computedValue
                computedValue