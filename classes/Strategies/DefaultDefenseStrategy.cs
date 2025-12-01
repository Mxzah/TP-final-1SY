class DefaultDefenseStrategy : IDefenseStrategy
{
    public string Name => "Default strategy";

    public int Mitigate(Player defender, Defense? defense, int defenseValue, int incomingDamage)
    {
        int mitigatedDamage = incomingDamage - defenseValue;
        return mitigatedDamage < 0 ? 0 : mitigatedDamage;
    }
}
