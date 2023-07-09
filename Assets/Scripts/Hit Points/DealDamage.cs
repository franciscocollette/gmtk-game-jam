using Sirenix.OdinInspector;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private Tags target;

    [SerializeField] private float damage;

    [SerializeField] private Stat bonusDmg;


    [SerializeField, EnumToggleButtons] private TypeCollision type;

    private IOnImpact[] onImpacts;

    private void Awake()
    {
        onImpacts = GetComponentsInChildren<IOnImpact>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (type != TypeCollision.OnEnter)
            return;
        OnImpact(other);
    }


    private void OnTriggerStay(Collider other)
    {
        if (type != TypeCollision.OnStay)
            return;
        OnImpact(other);
    }
    private void OnImpact(Collider other)
    {
        if (!other.CompareTag(target))
            return;
        if (other.TryGetComponent<HitPoints>(out var hp))
        {
            var bonus = GlobalStats.Instance.GetValueNormalized(bonusDmg);
            hp.DealDamage(damage * bonus);
        }
        foreach (var item in onImpacts)
        {
            item.OnImpact(other);
        }
    }



    enum TypeCollision
    {
        OnStay,
        OnEnter
    }
}
