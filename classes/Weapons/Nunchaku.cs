class Nunchaku : Weapon
{
    private int damage = 15;

    public Nunchaku() { }

    public override int Attack()
    {
        return damage;
    }

    public override string AttackSound()
    {
        return "Whack!";
    }

}