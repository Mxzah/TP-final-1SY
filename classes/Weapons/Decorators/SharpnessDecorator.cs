class SharpnessDecorator : WeaponDecorator
{
    private readonly int _bonus = 5;
    public SharpnessDecorator(Weapon weapon) : base(weapon) { }
    public override int Attack()
    {
        return base.Attack() + _bonus;
    }

    public override string ToString()
    {
        return $"Sharpened {_weapon.ToString()}";
    }
}