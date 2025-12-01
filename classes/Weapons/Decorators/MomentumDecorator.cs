class MomentumDecorator : WeaponDecorator
{
    private readonly float _momentumMultiplier = 1.5f;
    public MomentumDecorator(Weapon weapon) : base(weapon) { }

    public override int Attack()
    {
        return (int)(base.Attack() * _momentumMultiplier);
    }
    public override string ToString()
    {
        return $"Momentum {_weapon.ToString()}";
    }
}