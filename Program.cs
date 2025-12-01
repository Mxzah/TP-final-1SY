
static void Main()
{
    Player player1 = new Player("Hero");
    Player player2 = new Player("Villain");

    Weapon regularKatana = new Katana();
    Weapon regularNunchaku = new Nunchaku();
    Weapon regularShuriken = new Shuriken();

    var weapons = new Weapon[]
    {
        regularKatana,
        new SharpnessDecorator(regularKatana),
        regularShuriken,
        new SharpnessDecorator(regularShuriken),
        regularNunchaku,
        new MomentumDecorator(regularNunchaku),
        new MomentumDecorator(new SharpnessDecorator(regularKatana)),

    };

    Defense regularSmokeBomb = new SmokeBomb();
    Defense regularShield = new Shield();
    Defense regularRoll = new Roll();
    
    var defenses = new Defense[]
    {
        regularSmokeBomb,
        regularShield,
        regularRoll,
        new QuickReflexeDecorator(regularRoll),
        new QuickReflexeDecorator(regularSmokeBomb),
        new DiamondDecorator(regularShield)
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

    GameManager gameManager = new GameManager(player1, player2, weapons, defenses, attackStrategies, defenseStrategies, damageRatio: 2.0f, timeBetweenTurns: 2000);
    gameManager.StartGame();
}

Main();
