using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{

    [SerializeField] private ResourceSO[] resourses;
    private readonly Dictionary<ResourceSO, int> stored = new();

    protected override void Awake()
    {
        base.Awake();
        foreach (var item in resourses)
        {
            stored.Add(item, 0);

        }
    }

    public bool CanAfford(ResourceSO target, int amount) => stored[target] >= amount;

    public void GainResource(ResourceSO target, int amount) => stored[target] += amount;
    public void SpendResource(ResourceSO target, int amount) => stored[target] -= amount;
    public bool TryAfford(ResourceSO target, int amount)
    {
        var canAfford = CanAfford(target, amount);
        if (canAfford)
            SpendResource(target, amount);
        return canAfford;
    }
    public int GetAmount(ResourceSO target) => stored[target];
}
