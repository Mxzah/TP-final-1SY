class FortifiedDefenseStrategy : IDefenseStrategy
{
    public string Name => "Fortified strategy";

    public int Mitigate(Player defender, Defense? defense, int defenseValue, int incomingDamage)
    {
        int percentReduction = (int)MathF.Round(incomingDamage * 0.25f);
        int mitigatedDamage = incomingDamage - (defenseValue + percentReduction);
        return mitigatedDamage < 0 ? 0 : mitigatedDamage;
    }
}
