class Shield : Defense
{
    private readonly int defenseValue = 10;

    public Shield() { }
 
    public override int Defend()
    {
        return defenseValue;
    }
 
    public override string DefendSound()
    {
        return "Clang!";
    }
}