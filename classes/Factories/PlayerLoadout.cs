class PlayerLoadout
{
    public Weapon Weapon { get; }
    public Defense Defense { get; }
    public IAttackStrategy AttackStrategy { get; }
    public IDefenseStrategy DefenseStrategy { get; }

    public PlayerLoadout(Weapon weapon, Defense defense, IAttackStrategy attackStrategy, IDefenseStrategy defenseStrategy)
    {
        Weapon = weapon;
        Defense = defense;
        AttackStrategy = attackStrategy;
        DefenseStrategy = defenseStrategy;
    }
}
