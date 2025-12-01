interface IAttackStrategy
{
    int Execute(Player attacker, Weapon? weapon);
    string Name { get; }
}
