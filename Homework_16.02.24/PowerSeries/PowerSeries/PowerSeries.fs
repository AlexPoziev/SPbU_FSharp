module PowerSeries

let powerSeries (n, m) =
    if (n < 0 || m < 0) then None else
        
    let endLimit = pown 2 (n + m)
    let rec helper acc element i =
        match i with
        | 0 -> Some(acc)
        | _ -> helper (element :: acc) (element / 2) (i - 1)
    helper [endLimit] (endLimit / 2) m
