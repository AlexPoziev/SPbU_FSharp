namespace LocalNetwork

type public IOperatingSystem =
    abstract member Name: string
    abstract member InfectionProbability: int