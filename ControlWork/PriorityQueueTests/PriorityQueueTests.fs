module PriorityQueueTests

open System
open NUnit.Framework
open FsUnit
open ControlWork

[<Test>]
let Dequeue_WithEmptyQueue_ThrowsInvalidOperationException () =
    let queue = PriorityQueue()
    Assert.Throws<InvalidOperationException>(fun () -> queue.Dequeue()) |> ignore
    
[<Test>]
let EnqueueAndDequeue_WithCorrectData_ShouldPerformExpectedResult () =
    let pq = PriorityQueue<int>()
    pq.Enqueue(1)
    pq.Enqueue(4)
    pq.Enqueue(3)
    pq.Enqueue(2)

    pq.Dequeue() |> should equal 4
    pq.Dequeue() |> should equal 3
    pq.Dequeue() |> should equal 2
    pq.Dequeue() |> should equal 1
