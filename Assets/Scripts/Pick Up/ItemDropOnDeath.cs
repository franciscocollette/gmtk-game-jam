using UnityEngine;

public class ItemDropOnDeath : MonoBehaviour, IOnDeath
{
    [SerializeField] private GameObject pickUp;

    [SerializeField] private int amount = 1;

    [SerializeField] private float randRadius = .5f;


    [SerializeField,Range(0,1)] private float dropChance = 1;

    public void OnDeath()
    {
        if (Random.value >= dropChance)
        {
            return;
        }


        for (int i = 0; i < amount; i++)
        {
            var randDir = Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.right * randRadius;
            Instantiate(pickUp, transform.position + randDir, Quaternion.identity);
        }
    }
}
