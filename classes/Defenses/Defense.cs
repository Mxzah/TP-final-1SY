abstract class Defense
{
    public abstract int Defend();
    public abstract string DefendSound();

    public override string ToString()
    {
        return $"{GetType().Name}";
    }
}