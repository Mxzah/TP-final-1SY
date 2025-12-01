class DefaultAttackStrategy : IAttackStrategy
{
    public string Name => "Default attack";

    public int Execute(Player attacker, Weapon? weapon)
    {
        if (weapon == null)
        {
            return 5;
        }

        return weapon.Attack();
    }
}
