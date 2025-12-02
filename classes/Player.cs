class Player : ISubject, IComparable<Player>
{
    private string _name = string.Empty;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private int _healthPoints;
    public int HealthPoints
    {
        get { return _healthPoints; }
        set
        {
            _healthPoints = value;
            if (_healthPoints < 0)
            {
                _healthPoints = 0;
            }
            if (_healthPoints > 100)
            {
                _healthPoints = 100;
            }
        }
    }
    public Weapon? Weapon { get; private set; }
    public Defense? Defense { get; private set; }
    private IAttackStrategy _attackStrategy = new DefaultAttackStrategy();
    public IAttackStrategy AttackStrategy => _attackStrategy;
    private IDefenseStrategy _defenseStrategy = new DefaultDefenseStrategy();
    public IDefenseStrategy DefenseStrategy => _defenseStrategy;

    private List<IObserver> observers = new List<IObserver>();
    public Player(string name)
    {
        Name = name;
        HealthPoints = 100;
    }
    public void EquipWeapon(Weapon weapon)
    {
        Weapon = weapon;
    }
    public void EquipDefense(Defense defense)
    {
        Defense = defense;
    }
    public void SetAttackStrategy(IAttackStrategy strategy)
    {
        _attackStrategy = strategy ?? new DefaultAttackStrategy();
    }
    public void SetDefenseStrategy(IDefenseStrategy strategy)
    {
        _defenseStrategy = strategy ?? new DefaultDefenseStrategy();
    }
    public void Attack(Player target)
    {
        var weapon = Weapon;
        int damage = _attackStrategy.Execute(this, weapon);
        string sound = weapon?.AttackSound() ?? string.Empty;
        Console.WriteLine($"{Name} uses {_attackStrategy.Name} strategy.");
        if (!string.IsNullOrEmpty(sound))
        {
            Console.WriteLine($"{Name} attacks with: {weapon?.ToString() ?? "Unarmed"} - Sound: {sound}");
        }
        target.TakesDamage(damage);
    }
    public void TakesDamage(int damage)
    {
        var defense = Defense;
        int defenseValue = defense?.Defend() ?? 0;
        string defenseSound = defense?.DefendSound() ?? string.Empty;

        Console.WriteLine($"{Name} uses {_defenseStrategy.Name} defense.");

        int mitigatedDamage = _defenseStrategy.Mitigate(this, defense, defenseValue, damage);
        if (mitigatedDamage < 0)
        {
            mitigatedDamage = 0;
        }

        if (defense != null && !string.IsNullOrEmpty(defenseSound))
        {
            Console.WriteLine($"{Name} defends with: {defense.ToString()} - Sound: {defenseSound}");
        }

        HealthPoints -= mitigatedDamage;
        Notify(-mitigatedDamage);
    }
    
    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Reset()
    {
        HealthPoints = 100;
        Notify(0);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(int delta)
    {
        foreach (var observer in observers)
        {
            observer.Update(delta, HealthPoints, this);
        }
    }

    public int CompareTo(Player? other)
    {
        if (other == null)
        {
            return 1;
        }

        int healthComparison = HealthPoints.CompareTo(other.HealthPoints);
        if (healthComparison != 0)
        {
            return healthComparison;
        }

        return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }
}
