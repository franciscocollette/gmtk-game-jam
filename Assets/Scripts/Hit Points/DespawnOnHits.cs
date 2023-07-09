using UnityEngine;

public class DespawnOnHits : MonoBehaviour, IOnImpact
{

    [SerializeField] private int hits = 1;

    [SerializeField] private Stat extraPiercing;



    public void OnImpact(Collider target)
    {
        var extra = GlobalStats.Instance.GetValue(extraPiercing);
        hits--;
        if (hits + extra <= 0)
            Destroy(gameObject);
    }
}
