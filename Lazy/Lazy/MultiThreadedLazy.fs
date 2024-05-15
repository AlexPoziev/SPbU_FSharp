namespace Lazy

type MultiThreadedLazy<'a>(supplier: unit -> 'a) =
    [<VolatileField>]
    let mutable value = None
    let lockObj = obj()

    interface ILazy<'a> with
        member this.Get() =
            if value.IsNone then
                lock lockObj (fun () ->
                    if value.IsNone then
                        value <- Some (supplier())
                )
            value.Value