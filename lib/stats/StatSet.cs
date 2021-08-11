
using System.Collections.Generic;

public class StatSet
{

    private List<Stat> _stats;
    public IReadOnlyCollection<Stat> Stats;

    public StatSet()
    {
        _stats = new List<Stat>();

        // Stats
        _stats.Add(new Stat("current_health", 0));
        _stats.Add(new Stat("max_health", 0));
        _stats.Add(new Stat("physical_attack", 0));
        _stats.Add(new Stat("physical_armor", 0));
        
        Stats = _stats.AsReadOnly();
    }

    public Stat GetStatByName(string name)
    {
        return _stats.Find(stat => stat.Name == name);
    }

    public bool SetStatBaseValue(string name, float value)
    {
        if(_stats.Find(stat => stat.Name == name) != null && value > 0)
        {
            _stats.Find(stat => stat.Name == name).BaseValue = value;
            return true;
        }
        return false;
    }

    public bool AddStatModifier(string name, StatModifier modifier)
    {
        if (_stats.Find(stat => stat.Name == name) != null)
        {
            return _stats.Find(stat => stat.Name == name).AddModifier(modifier);
        }
        
        return false;
    }

    public bool RemoveStatModifier(string name, StatModifier modifier)
    {
        Stat target = _stats.Find(stat => stat.Name == name);
        if (target != null)
        {
            return target.RemoveModifier(modifier);
        }

        return false;
    }
}