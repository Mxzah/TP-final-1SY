class HealthBar : IObserver
{
    public void Update(int delta, int currentHealth, Player target)
    {
        if (delta <= 0)
        {
            UpdateLoss(currentHealth, -delta);
        }
    }
    public void UpdateLoss(int currentHealth, int damage)
    {
        Console.WriteLine($"Health Bar : {currentHealth} (Lost {damage} hp)");
    }

}
