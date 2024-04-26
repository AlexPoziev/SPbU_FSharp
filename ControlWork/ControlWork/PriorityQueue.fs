namespace ControlWork

type PriorityQueue<'T when 'T : comparison>() =
    let mutable list = []

    // function to add element to queue 
    member this.Enqueue(item: 'T) =
        let rec helper orderedList =
            match orderedList with
            | [] -> [item]
            | head :: _ when item > head -> item :: orderedList
            | head :: tail -> head :: (helper tail)
        list <- helper list

    // function to get element from queue
    member this.Dequeue() =
        match list with
        | [] -> raise <| System.InvalidOperationException("Empty queue")
        | head :: tail ->
            list <- tail
            head
