class GameManager
{
    private Player _player1;
    private Player _player2;
    private float _damageRatio;
    private int _timeBetweenTurns;
    private HealthBar _healthBarPlayer1;
    private HealthBar _healthBarPlayer2;
    private GameOverManager _gameOverManager;
    private readonly ILoadoutFactory _loadoutFactory;
    public GameManager(Player player1, Player player2, ILoadoutFactory loadoutFactory, float damageRatio = 1f, int timeBetweenTurns = 1000)
    {
        _player1 = player1;
        _player2 = player2;
        _loadoutFactory = loadoutFactory ?? throw new ArgumentNullException(nameof(loadoutFactory));

        _damageRatio = damageRatio;
        _timeBetweenTurns = timeBetweenTurns;
        
        _healthBarPlayer1 = new HealthBar();
        _healthBarPlayer2 = new HealthBar();
        _gameOverManager = new GameOverManager();

        _player1.Attach(_healthBarPlayer1);
        _player1.Attach(_gameOverManager);
        _player2.Attach(_healthBarPlayer2);
        _player2.Attach(_gameOverManager);


    }

    public void StartGame()
    {
        int counter = 1;
        while (true)
        {
            for (int i = 0; i < counter; i++)
            {
                ApplyLoadout(_player1);
                ApplyLoadout(_player2);

                if (i % 2 == 0)
                {
                    Console.WriteLine($"\n{_player1.Name}'s turn:");
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine($"\n{_player2.Name}'s turn:");
                    _player2.Attack(_player1);
                }

                DisplayLeaderboard();
                Thread.Sleep(_timeBetweenTurns);

                if (GameOverManager.IsGameOver)
                {
                    Console.WriteLine("\nPress Space to restart, or 'q' to quit.");
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            GameOverManager.Reset();
                            _player1.Reset();
                            _player2.Reset();
                            counter = 1;
                            Console.WriteLine("Game restarted.");
                            break;
                        }
                        else if (key.Key == ConsoleKey.Q)
                        {
                            Console.WriteLine("Exiting game.");
                            return;
                        }
                    }
                }

                counter++;
            }
        }
    }

    private void ApplyLoadout(Player player)
    {
        var loadout = _loadoutFactory.CreateLoadout();
        player.EquipWeapon(loadout.Weapon);
        player.EquipDefense(loadout.Defense);
        player.SetAttackStrategy(loadout.AttackStrategy);
        player.SetDefenseStrategy(loadout.DefenseStrategy);
    }

    private void DisplayLeaderboard()
    {
        Player[] leaderboard = new[] { _player1, _player2 };
        Array.Sort(leaderboard, (a, b) => b.CompareTo(a));

        Console.WriteLine("\nLeaderboard (HP high to low):");
        for (int rank = 0; rank < leaderboard.Length; rank++)
        {
            var player = leaderboard[rank];
            Console.WriteLine($"  #{rank + 1}: {player.Name} - {player.HealthPoints} HP");
        }
    }
}