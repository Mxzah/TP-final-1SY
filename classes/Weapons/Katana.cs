class Katana : Weapon
{
    private int damage = 20;

    public Katana() { }

    public override int Attack()
    {
        return damage;
    }

    public override string AttackSound()
    {
        return "Swish!";
    }

}