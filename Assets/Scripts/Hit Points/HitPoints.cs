using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HitPoints : MonoBehaviour
{
    [field: SerializeField] public int MaxHP { get; private set; }
    [field: SerializeField] public float CurrentHP { get; private set; }

    [SerializeField] private UnityEvent<float> onDmg;
    [SerializeField] private UnityEvent<float> onHeal;
    [SerializeField] private UnityEvent onDeath;

    [SerializeField] private float inmuneDur;

    private bool isInmune = false;


    private IOnDmg[] takeDmgs;
    private IOnDeath[] onDeaths;
    private IOnHeal[] onHeals;

    private void Awake()
    {
        CurrentHP = MaxHP;
        takeDmgs = GetComponentsInChildren<IOnDmg>();
        onDeaths = GetComponentsInChildren<IOnDeath>();
        onHeals = GetComponentsInChildren<IOnHeal>();
    }
    private void Start()
    {
        isInmune = false;
    }
    public void DealDamage(float amount)
    {
        if (CurrentHP <= 0)
            return;
        if (isInmune)
            return;

        CurrentHP -= amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);

        foreach (var item in takeDmgs)
        {
            item.OnDmg(amount);
        }
        onDmg.Invoke(amount);

        if (inmuneDur > 0)
            StartCoroutine(Routine());

        if(CurrentHP <= 0)
        {
            foreach (var item in onDeaths)
            {
                item.OnDeath();
            }
            onDeath.Invoke();
            Destroy(gameObject);
        }

        IEnumerator Routine()
        {
            isInmune = true;
            yield return new WaitForSeconds(inmuneDur);
            isInmune = false;
        }
    }

    public void Heal(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
        foreach (var item in onHeals)
        {
            item.OnHeal(amount);
        }
        onHeal.Invoke(amount);
    }
}

public interface IOnDmg
{
    public void OnDmg(float amount);
}
public interface IOnHeal
{
    public void OnHeal(float amount);
}
public interface IOnDeath
{
    public void OnDeath();
}
