class AdaptiveDefenseStrategy : IDefenseStrategy
{
    public string Name => "Adaptive strategy";

    public int Mitigate(Player defender, Defense? defense, int defenseValue, int incomingDamage)
    {
        int clutchBonus = defender.HealthPoints < 40 ? 6 : 2;
        int mitigatedDamage = incomingDamage - (defenseValue + clutchBonus);
        return mitigatedDamage < 0 ? 0 : mitigatedDamage;
    }
}
