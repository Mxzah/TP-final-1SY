abstract class Weapon
{
    public abstract int Attack();
    public abstract string AttackSound();

    public override string ToString()
    {
        return $"{GetType().Name}";
    }
}