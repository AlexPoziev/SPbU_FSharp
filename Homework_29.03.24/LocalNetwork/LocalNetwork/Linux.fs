namespace LocalNetwork

type Linux(?infectionProbability: int) =
    let defaultProbability = defaultArg infectionProbability 20
    
    interface IOperatingSystem with
        member val InfectionProbability = defaultProbability with get
        member val Name = "Linux" with get
        