class Shuriken : Weapon
{
    private int damage = 10;

    public Shuriken() { }

    public override int Attack()
    {
        return damage;
    }

    public override string AttackSound()
    {
        return "Ding!";
    }


}