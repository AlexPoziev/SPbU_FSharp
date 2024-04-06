namespace LocalNetwork

open System.Collections.Generic

type LocalNetwork(computersNetwork: Dictionary<Computer, Computer list>) =
    let mutable _computersNetwork = computersNetwork
    
    let _computers = computersNetwork.Keys |> Seq.toList
    
    member this.ComputersNetwork
        with get() = _computersNetwork
        and private set network = _computersNetwork <- network
        
    member private this.GetComputersWithPossibleActions () =
        _computers
            |> List.filter (fun x -> x.IsInfected && computersNetwork[x] |> List.exists (fun t -> not t.IsInfected))
       
    member this.MakeTurn () =
        let computers = this.GetComputersWithPossibleActions()
        if (computers.Length > 0) then
            computers
                |> List.map (fun x -> this.ComputersNetwork[x])
                |> List.concat
                |> List.iter (_.InfectComputer())
            true
        else
            false 
       
    member this.StartModel () =
        while this.MakeTurn() do
            _computers |> List.iter (fun i -> printfn $"Computer {i.SerialNumber} is infected: {i.IsInfected}")
            
    member this.GetStatus () =
        _computers |> List.map (_.IsInfected)