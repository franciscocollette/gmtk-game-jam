using System.Collections;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private float innerRadius;
    [SerializeField] private float outherRadius;
    [SerializeField] private float cooldown;


    [SerializeField] private LayerMask resourceTag;
    [SerializeField] private float castRadius = .1f;

    [SerializeField] private int maxIteration = 50;

    [SerializeField] private int startingTrees;


    [SerializeField] private GameObject treePf;

    private IEnumerator Start()
    {
        for (int i = 0; i < startingTrees; i++)
        {
            TrySpawnTree();
        }

        while (true)
        {
            if (TrySpawnTree())
            {
                yield return new WaitForSeconds(cooldown);

            }
            else
                yield return new WaitForSeconds(cooldown * 1.5f); // wait a bit linger
        }
    }
    private bool TrySpawnTree()
    {
        for (int i = 0; i < maxIteration; i++)
        {
            var randDir = Quaternion.Euler(0, Random.Range(0, 360), 0);
            var dir = randDir * new Vector3(Random.Range(innerRadius, outherRadius), 0, 0);
            var position = transform.position + dir;
            if (CanSpawnTree(position))
            {
                Instantiate(treePf, position, Quaternion.identity);
                return true;
            }            
        }
        return false;
    }
    private bool CanSpawnTree(Vector3 position) => !Physics.CheckSphere(position, castRadius, resourceTag);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, innerRadius);
        Gizmos.DrawWireSphere(transform.position, outherRadius);
    }
}
