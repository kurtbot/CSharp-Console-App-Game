
public abstract class Entity
{
    public StatSet Stats;

    protected string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    
    public bool IsAlive = true;

    public Entity(string name)
    {
        _name = name;
        Stats = new StatSet();
    }

    public Stat GetStat(string statName)
    {
        return Stats.GetStatByName(statName);
    }

    public abstract float Attack(Entity entity);
    public abstract float Defend(Entity entity);

    public abstract Damage[] GetDamage();
}