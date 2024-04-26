namespace ControlWork

type PriorityQueue<'T when 'T : comparison>() =
    let mutable list = []

    member this.Enqueue(item: 'T) =
        let rec helper orderedList =
            match orderedList with
            | [] -> [item]
            | head :: _ when item > head -> item :: orderedList
            | head :: tail -> head :: (helper tail)
        list <- helper list

    member this.Dequeue() =
        match list with
        | [] -> raise <| System.InvalidOperationException("Empty queue")
        | head :: tail ->
            list <- tail
            head
