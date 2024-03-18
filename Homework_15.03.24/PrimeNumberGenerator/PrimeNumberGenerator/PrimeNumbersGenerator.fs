namespace PrimeNumbers

module Generator =
    let isPrime num =
        let max = num |> float |> sqrt |> int
        Seq.exists (fun x -> num % x = 0) {2..max} |> not
        
    let primeNumbers =
        Seq.initInfinite(fun elem -> elem + 2) |> Seq.filter isPrime