namespace LocalNetwork

type Windows(?infectionProbability: int) =
    let defaultProbability = defaultArg infectionProbability 90
    
    interface IOperatingSystem with
        member val InfectionProbability = defaultProbability with get
        member val Name = "Windows" with get