using System.Collections;
using UnityEngine;

public class FireStatusEffect : MonoBehaviour
{
    [SerializeField] private float damage = 50;
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private float duration = 3f;

    [SerializeField] private HitPoints hitPoints;

    [SerializeField] private GameObject whileOnFire;

    private int stacks;
    private IEnumerator Start()
    {
        while (true)
        {
            if (stacks > 0)
                hitPoints.DealDamage(damage);
            yield return new WaitForSeconds(cooldown);
        }
    }

    private void Update()
    {
        whileOnFire.SetActive(stacks > 0);
    }

    public void Stack()
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            stacks++;
            yield return new WaitForSeconds(duration);
            stacks--;
        }
    }

}