class RandomLoadoutFactory : ILoadoutFactory
{
    private readonly Func<Weapon>[] _weaponFactories;
    private readonly Func<Defense>[] _defenseFactories;
    private readonly IAttackStrategy[] _attackStrategies;
    private readonly IDefenseStrategy[] _defenseStrategies;

    public RandomLoadoutFactory(IEnumerable<Func<Weapon>> weaponFactories,
        IEnumerable<Func<Defense>> defenseFactories,
        IEnumerable<IAttackStrategy> attackStrategies,
        IEnumerable<IDefenseStrategy> defenseStrategies)
    {
        _weaponFactories = weaponFactories?.ToArray() ?? throw new ArgumentNullException(nameof(weaponFactories));
        _defenseFactories = defenseFactories?.ToArray() ?? throw new ArgumentNullException(nameof(defenseFactories));
        _attackStrategies = attackStrategies?.ToArray() ?? throw new ArgumentNullException(nameof(attackStrategies));
        _defenseStrategies = defenseStrategies?.ToArray() ?? throw new ArgumentNullException(nameof(defenseStrategies));

        if (_weaponFactories.Length == 0)
        {
            throw new ArgumentException("At least one weapon factory is required", nameof(weaponFactories));
        }
        if (_defenseFactories.Length == 0)
        {
            throw new ArgumentException("At least one defense factory is required", nameof(defenseFactories));
        }
        if (_attackStrategies.Length == 0)
        {
            throw new ArgumentException("At least one attack strategy is required", nameof(attackStrategies));
        }
        if (_defenseStrategies.Length == 0)
        {
            throw new ArgumentException("At least one defense strategy is required", nameof(defenseStrategies));
        }
    }

    public PlayerLoadout CreateLoadout()
    {
        Weapon weapon = _weaponFactories[Random.Shared.Next(_weaponFactories.Length)]();
        Defense defense = _defenseFactories[Random.Shared.Next(_defenseFactories.Length)]();
        IAttackStrategy attackStrategy = _attackStrategies[Random.Shared.Next(_attackStrategies.Length)];
        IDefenseStrategy defenseStrategy = _defenseStrategies[Random.Shared.Next(_defenseStrategies.Length)];

        return new PlayerLoadout(weapon, defense, attackStrategy, defenseStrategy);
    }
}
