using UnityEngine;

public class FireDamage : MonoBehaviour, IOnImpact
{

    [SerializeField] private Stat fire;

    public void OnImpact(Collider target)
    {
        if (!GlobalStats.Instance.IsEnable(fire))
            return;
        if (target.TryGetComponent<FireStatusEffect>(out var statusEffect))
            statusEffect.Stack();
    }
}
