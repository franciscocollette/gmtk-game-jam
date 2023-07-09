using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class GlobalStats : Singleton<GlobalStats>
{
    private Dictionary<Stat, float> stats = new();

    public void AddBonus(Stat target, float value)
    {
        ChecKStat(target);
        stats[target] += value;
    }
    public float GetValue(Stat target)
    {
        ChecKStat(target);
        return stats[target];
    }
    public float GetValueNormalized(Stat target) => 1 + (GetValue(target) / 100);

    public bool IsEnable(Stat target) => GetValue(target) > 0;

    private void ChecKStat(Stat stat) => stats.TryAdd(stat, 0);
}
