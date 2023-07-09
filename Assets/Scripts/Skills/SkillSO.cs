using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(menuName = "Abyssal Tree/Skill")]
public class SkillSO : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }


    [SerializeField] private Stat levelUp;
    [SerializeField] private float levelUpBonus;

    [SerializeField] private Stat unlockStat;
    [SerializeField] private float unlockBonus;

    [SerializeField] private LevelUpCost[] levels;

    [SerializeField] private SkillSO[] requirement;

    public bool IsMaxLevel => CurrentLevel >= levels.Length;
    public int CurrentLevel => SkillManager.Instance.GetLevel(this);
    public bool AtLeastOneLevel => CurrentLevel >= 1;
    public LevelUpCost Cost => levels[CurrentLevel];

    public void TryLevelUp()
    {
        if (IsMaxLevel)
            return;
        Debug.Log("Max Level");
        if (!CanAfford())
            return;
        Debug.Log("Can aford Level");
        if (IsLocked())
            return;
        Debug.Log("I locked");
                
        Purchase();
        SkillManager.Instance.AddLevel(this);
        GlobalStats.Instance.AddBonus(levelUp,levelUpBonus);
        if(CurrentLevel == 1)
            GlobalStats.Instance.AddBonus(unlockStat, unlockBonus);
               
    }

    public bool CanAfford()
    {
        foreach (var item in levels[CurrentLevel].Resources)
        {
            if (!ResourceManager.Instance.CanAfford(item.Resource, item.amount))
                return false;
        }
        return true;
    }
    public bool IsLocked()
    {
        foreach (var item in requirement)
        {
            if (!item.AtLeastOneLevel)
                return true;
        }
        return false;
    }
    public void Purchase()
    {
        foreach (var item in levels[CurrentLevel].Resources)
        {
            ResourceManager.Instance.SpendResource(item.Resource, item.amount);
        }
    }

}
    [System.Serializable]
    public class LevelUpCost
    {

        [field: SerializeField,TableList] public ResourceCost[] Resources { get; private set; }

    }

    [System.Serializable]
    public class ResourceCost
    {

        [field: SerializeField] public ResourceSO Resource { get; private set; }
        [field: SerializeField] public int amount { get; private set; }

    }