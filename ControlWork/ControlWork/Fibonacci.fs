module ControlWork.Fibonacci

let sumEvenFibonacci max =
    let rec loop a b sum =
        if a > max then sum
        else
            let nextSum = if a % 2 = 0 then sum + a else sum
            loop b (a + b) nextSum
    loop 1 2 0

