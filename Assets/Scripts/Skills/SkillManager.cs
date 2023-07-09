using System.Collections.Generic;

public class SkillManager : Singleton<SkillManager>
{
    private Dictionary<SkillSO, int> skillLevels = new();
    public void AddLevel(SkillSO target)
    {
        skillLevels.TryAdd(target, 0);
        skillLevels[target]++;
    }
    public int GetLevel(SkillSO target)
    {
        skillLevels.TryAdd(target, 0);
        return skillLevels[target];
    }
}
