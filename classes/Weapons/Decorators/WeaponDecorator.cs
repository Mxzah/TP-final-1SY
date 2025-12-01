abstract class WeaponDecorator : Weapon
{
    protected Weapon _weapon;

    public WeaponDecorator(Weapon weapon)
    {
        _weapon = weapon;
    }

    public override int Attack()
    {
        return _weapon.Attack();
    }

    public override string AttackSound()
    {
        return _weapon.AttackSound();
    }

}