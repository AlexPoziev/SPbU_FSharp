namespace LocalNetwork

type Computer(system: IOperatingSystem, connectedComputers: Computer list, isInfected: bool, serialNumber: string) =
    let randomNumberGenerator = System.Random()
    
    member val SerialNumber = serialNumber with get
    member val OperatingSystem = system with get
    member val ConnectedComputers = connectedComputers with get, set
    member val IsInfected = isInfected with get, set
    
    member this.ConnectComputers computers =
        this.ConnectedComputers <- computers @ this.ConnectedComputers
        
    member this.InfectComputer () =
        if (randomNumberGenerator.Next(0, 100) <= this.OperatingSystem.InfectionProbability) then
            this.IsInfected <- true
