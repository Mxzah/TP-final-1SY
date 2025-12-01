interface IDefenseStrategy
{
    string Name { get; }
    int Mitigate(Player defender, Defense? defense, int defenseValue, int incomingDamage);
}
