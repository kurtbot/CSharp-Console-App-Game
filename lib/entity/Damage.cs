using System;


public abstract class Damage
{
    public readonly string DamageType;
    public Entity Entity;
    public bool IsCrit;

    public Damage(Entity entity, string damageType)
    {
        Entity = entity;
        DamageType = damageType;

        // todo: Implement crit chance
        // var rand = new Random();

    }
}