using System;
using System.Collections.Generic;


public class Stat
{
    private string _name;
    public string Name
    {
        get { return _name; }
    }

    private float _lastBaseValue;
    private float _baseValue;
    public float BaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    private float _finalValue;
    public float FinalValue
    {
        get
        {
            if (_isModified || BaseValue != _lastBaseValue)
            {
                _lastBaseValue = BaseValue;
                _finalValue = CalculateFinalValue();
                _isModified = false;
            }

            return _finalValue;
        }
    }

    private bool _isModified = true;

    private List<StatModifier> _modifiers;

    public Stat(string name, float baseValue)
    {
        _name = name;
        _baseValue = baseValue;
        _modifiers = new List<StatModifier>();
    }

    public bool AddModifier(StatModifier modifier)
    {
        _isModified = true;
        _modifiers.Add(modifier);
        _modifiers.Sort(StatModifier.CompareModifierOrder);
        return true;
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        if (_modifiers.Remove(modifier))
        {
            _isModified = true;
            return true;
        }

        return false;
    }

    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < _modifiers.Count; i++)
        {
            StatModifier mod = _modifiers[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;

                if (i + 1 >= _modifiers.Count || _modifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }

}