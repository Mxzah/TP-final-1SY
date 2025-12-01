class PreciseAttackStrategy : IAttackStrategy
{
    public string Name => "Precise attack";

    public int Execute(Player attacker, Weapon? weapon)
    {
        int baseDamage = weapon?.Attack() ?? 5;
        int bonus = attacker.HealthPoints > 50 ? 4 : 2;
        return baseDamage + bonus;
    }
}
