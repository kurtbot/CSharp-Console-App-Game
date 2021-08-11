
using System.Collections.Generic;

public class TestCharacter : Entity
{
    public TestCharacter(string name) : base(name)
    {
        Stats.SetStatBaseValue("current_health", 100);
        Stats.SetStatBaseValue("max_health", 100);
        Stats.SetStatBaseValue("physical_attack", 10);
        Stats.SetStatBaseValue("physical_armor", 5);
    }

    public override float Attack(Entity entity)
    {
        return entity.Defend(this);
    }

    public override float Defend(Entity entity)
    {
        Damage[] damages = entity.GetDamage();

        float totalDamage = 0;

        foreach (Damage dmg in damages)
        {
                    
            if (dmg is PhysicalDamage)
            {
                float value = entity.GetStat("physical_attack").FinalValue;
    
                float current_health = this.GetStat("current_health").BaseValue - value;
                this.Stats.SetStatBaseValue("current_health", current_health);
                totalDamage += value;
            }
        }

        if(this.GetStat("current_health").BaseValue <= 0)
        {
            IsAlive = false;
        }

        return totalDamage;
    }

    public override Damage[] GetDamage()
    {
        List<Damage> damages = new List<Damage>();
        damages.Add(new PhysicalDamage(this, "physical_attack"));
        // make if statements based on character weapon

        return damages.ToArray();
    }

    public override string ToString()
    {

        string data = $"{_name}\t[{GetStat("current_health").BaseValue}/{GetStat("max_health").FinalValue}]\tAttack Damage: {GetStat("physical_attack").FinalValue}\tPhysical Armor: {GetStat("physical_armor").FinalValue}";

        return data;
    }
}