namespace LocalNetwork

type MacOS(?infectionProbability: int) =
    let defaultProbability = defaultArg infectionProbability 5
    
    interface IOperatingSystem with
        member val InfectionProbability = defaultProbability with get
        member val Name = "MacOS" with get