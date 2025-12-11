
static void Main()
{
    Player player1 = new Player("Hero");
    Player player2 = new Player("Villain");

    var weaponFactories = new Func<Weapon>[]
    {
        () => new Katana(),
        () => new SharpnessDecorator(new Katana()),
        () => new Shuriken(),
        () => new SharpnessDecorator(new Shuriken()),
        () => new Nunchaku(),
        () => new MomentumDecorator(new Nunchaku()),
        () => new MomentumDecorator(new SharpnessDecorator(new Katana())),
    };

    var defenseFactories = new Func<Defense>[]
    {
        () => new SmokeBomb(),
        () => new Shield(),
        () => new Roll(),
        () => new QuickReflexeDecorator(new Roll()),
        () => new QuickReflexeDecorator(new SmokeBomb()),
        () => new DiamondDecorator(new Shield())
    };

    var attackStrategies = new IAttackStrategy[]
    {
        new DefaultAttackStrategy(),
        new AggressiveAttackStrategy(),
        new PreciseAttackStrategy()
    };

    var defenseStrategies = new IDefenseStrategy[]
    {
        new DefaultDefenseStrategy(),
        new AdaptiveDefenseStrategy(),
        new FortifiedDefenseStrategy()
    };

    ILoadoutFactory loadoutFactory = new RandomLoadoutFactory(weaponFactories, defenseFactories, attackStrategies, defenseStrategies);
    GameManager gameManager = GameManager.Initialize(player1, player2, loadoutFactory, damageRatio: 2.0f, timeBetweenTurns: 2000);
    gameManager.StartGame();
}

Main();
