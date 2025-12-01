class Roll : Defense
{
    private readonly int defenseValue = 8;

    public Roll() { }
    public override int Defend()
    {
        return defenseValue;
    }

    public override string DefendSound()
    {
        return "Whoosh!";
    }
}