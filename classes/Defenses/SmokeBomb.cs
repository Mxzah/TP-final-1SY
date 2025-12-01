class SmokeBomb : Defense
{
    private readonly int defenseValue = 5;

    public SmokeBomb() { }

    public override int Defend()
    {
        return defenseValue;
    }

    public override string DefendSound()
    {
        return "Pouff!";
    }
    
}