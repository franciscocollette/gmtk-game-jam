using System.Collections;
using UnityEngine;

public class HpRegen : MonoBehaviour
{
    [SerializeField] private Stat hpRegen;

    [SerializeField] private float cooldown = 1.5f;

    [SerializeField] private HitPoints hp;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            var healV = GlobalStats.Instance.GetValue(hpRegen);
            if (healV > 0)
                hp.Heal(healV);
        }
    }
}
