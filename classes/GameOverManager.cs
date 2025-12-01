class GameOverManager : IObserver
{
    public static bool IsGameOver { get; private set; } = false;
    public static string? LastDefeatedPlayer { get; private set; }

    public void Update(int delta, int currentHealth, Player target)
    {
        if (currentHealth <= 0 && !IsGameOver)
        {
            LastDefeatedPlayer = target?.Name;
            Console.WriteLine($"Player {LastDefeatedPlayer} has been defeated! Game Over!");
            IsGameOver = true;
        }
    }

    public static void Reset()
    {
        IsGameOver = false;
        LastDefeatedPlayer = null;
    }
}