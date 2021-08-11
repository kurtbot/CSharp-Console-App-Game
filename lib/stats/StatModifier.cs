public class StatModifier
{
    public readonly string Name;
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source;

    public StatModifier(string name, float value, StatModType type, int order, object source)
    {
        Name = name;
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }
    public StatModifier(string name, float value, StatModType type) : this(name, value, type, (int)type, null) { }
    public StatModifier(string name, float value, StatModType type, int order) : this(name, value, type, order, null) { }

    public static int CompareModifierOrder(StatModifier p, StatModifier q)
    {
        if (p.Order < q.Order)
            return -1;
        else if (p.Order > q.Order)
            return 1;
        return 0;   // if (p.Order == q.Order)
    }
}