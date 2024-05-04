module LazyTests

open NUnit.Framework
open System.Threading
open FsUnit
open Lazy

[<Test>]
let SingleThreadedLazy_ShouldComputeResultOnce () =
    let counter = ref 0
    let lazyObj = SingleThreadedLazy<unit>(fun () -> counter.Value <- counter.Value + 1) :> ILazy<unit>
    
    lazyObj.Get()
    lazyObj.Get()
    
    counter.Value |> should equal 1

let get_MultiThread_ShouldComputeOnce (createLazy: (unit -> obj) -> ILazy<obj>) () =
    let manualResetEvent = new ManualResetEvent(false)
    let counter = ref 0

    let supplier () =
        manualResetEvent.WaitOne() |> ignore
        Interlocked.Increment counter |> ignore
        obj ()
        
    let lazyObject = createLazy supplier
    
    let threadCount = 10
    let tasksArray = Seq.init threadCount (fun _ -> async { return lazyObject.Get() })

    let asyncResult = tasksArray |> Async.Parallel
    manualResetEvent.Set() |> ignore
    let results = asyncResult |> Async.RunSynchronously

    let firstResult = Seq.item 0 results

    results
        |> Seq.forall (fun object -> obj.ReferenceEquals(object, firstResult))
        |> should be True

[<Test>]
let MultiThreadedLazy_MultiThreadTest () =
    get_MultiThread_ShouldComputeOnce (fun supplier -> MultiThreadedLazy<obj>(supplier) :> ILazy<obj>) |> ignore

[<Test>]
let LockFreeLazy_MultiThreadTest () =
    get_MultiThread_ShouldComputeOnce (fun supplier -> LockFreeLazy<obj>(supplier) :> ILazy<obj>) |> ignore