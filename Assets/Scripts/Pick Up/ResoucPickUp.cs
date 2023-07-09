using UnityEngine;

public class ResoucPickUp : PickUp
{
    [SerializeField] private ResourceSO t;
    [SerializeField] private int a = 1;

    protected override void OnPickUp()
    {
        ResourceManager.Instance.GainResource(t, a);
    }
}
