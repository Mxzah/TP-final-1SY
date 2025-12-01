abstract class DefenseDecorator : Defense
{
    protected Defense _defense;

    public DefenseDecorator(Defense defense)
    {
        _defense = defense;
    }

    public override int Defend()
    {
        return _defense.Defend();
    }

    public override string DefendSound()
    {
        return _defense.DefendSound();
    }
}