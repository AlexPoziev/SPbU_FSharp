namespace LocalNetwork.Tests

open System.Collections.Generic
open NUnit.Framework
open LocalNetwork
open FsUnit

module LocalNetworkTests = 
    
    type ViruslessBrickOS () =
        interface IOperatingSystem with
            member val InfectionProbability = 0 with get
            member val Name = "Brick" with get
            
    type WindowsXP () =
        interface IOperatingSystem with
            member val InfectionProbability = 100 with get
            member val Name = "XP" with get
            
    let initLocalNetworkWithFiveHealthyComputers (healthyComputers: Computer array) =
        let infected = Computer(Windows(), [], true, "1")
        
        healthyComputers[0].ConnectComputers [healthyComputers[1]; infected]
        infected.ConnectComputers [healthyComputers[0]]
        healthyComputers[1].ConnectComputers [healthyComputers[2]; healthyComputers[3]]
        healthyComputers[2].ConnectComputers [healthyComputers[1]; healthyComputers[4]]
        healthyComputers[3].ConnectComputers [healthyComputers[1]; healthyComputers[4]]
        healthyComputers[4].ConnectComputers [healthyComputers[2]; healthyComputers[3]]
        
        let network = Dictionary<Computer, Computer list> ()
        
        network.Add (infected, infected.ConnectedComputers)
        healthyComputers |> Array.iter (fun x -> network.Add(x, x.ConnectedComputers))
        
        LocalNetwork(network)
        
    [<Test>]
    let MakeTurn_WithBricks_ShouldDoNothing () =
        let uninfectedComputers = Array.init 5 (fun i -> Computer(ViruslessBrickOS(), [], false, $"{i}"))

        let network = initLocalNetworkWithFiveHealthyComputers uninfectedComputers

        let isOver = network.MakeTurn()
        
        let allHealthy = uninfectedComputers |> Array.fold (fun acc x -> acc && not x.IsInfected) true
        
        Assert.That(isOver)
        Assert.That(allHealthy)
    
    [<Test>]
    let MakeTurn_WithXP_ShouldProduceExpectedResult () =
        let uninfectedComputers = Array.init 5 (fun i -> Computer(WindowsXP(), [], false, $"{i}"))

        let network = initLocalNetworkWithFiveHealthyComputers uninfectedComputers

        Assert.That(network.MakeTurn())
        network.GetStatus() |> should equal [true; true; false; false; false; false]
        
        Assert.That(network.MakeTurn())
        network.GetStatus() |> should equal [true; true; true; false; false; false]
        
        Assert.That(network.MakeTurn())
        network.GetStatus() |> should equal [true; true; true; true; true; false]
        
        Assert.That(network.MakeTurn())
        network.GetStatus() |> should equal [true; true; true; true; true; true]
        
        Assert.That(network.MakeTurn(), Is.False)
        network.GetStatus() |> should equal [true; true; true; true; true; true]