using UnityEngine;

public static class ExtentionMethods
{
    public static bool CompareTag(this Component component, Tags tags)
    {
        if (!component.TryGetComponent<UnitTag>(out var target))
            return false;
        return target.Tag == tags;
    }
}
