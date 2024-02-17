module PowerSeries

let powerSeries (n, m) =
    let twoToThePowerOfN = pown 2 n
    let rec helper acc element i =
        match i with
        | _ when i > m + n -> Some(acc)
        | _ when i >= n -> helper (acc @ [element * 2]) (element * 2) (i + 1)
        | _ -> None
    if (n < 0 || n + m < 0) then None
    else helper [twoToThePowerOfN] twoToThePowerOfN (n + 1)
