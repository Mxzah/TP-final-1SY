class DiamondDecorator : DefenseDecorator
{
    private readonly int additionalDefense = 5;

    public DiamondDecorator(Defense defense) : base(defense) { }

    public override int Defend()
    {
        return _defense.Defend() + additionalDefense;
    }

    public override string ToString()
    {
        return $"{_defense.ToString()} with Diamond Enhancement";
    }
}