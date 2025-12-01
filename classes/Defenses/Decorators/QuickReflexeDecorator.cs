class QuickReflexeDecorator : DefenseDecorator
{
    private readonly int bonusDefense = 3;

    public QuickReflexeDecorator(Defense defense) : base(defense) { }

    public override int Defend()
    {
        return base.Defend() + bonusDefense;
    }

    public override string DefendSound()
    {
        return base.DefendSound() + " Swift dodge!";
    }

    public override string ToString()
    {
        return $"{_defense.ToString()} And Quick Reflexes";
    }
}