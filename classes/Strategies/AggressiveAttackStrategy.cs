class AggressiveAttackStrategy : IAttackStrategy
{
    public string Name => "Aggressive attack";

    public int Execute(Player attacker, Weapon? weapon)
    {
        int baseDamage = weapon?.Attack() ?? 5;
        int burst = Random.Shared.Next(3, 8); // add unpredictable extra damage
        return (int)MathF.Ceiling(baseDamage * 1.3f) + burst;
    }
}
