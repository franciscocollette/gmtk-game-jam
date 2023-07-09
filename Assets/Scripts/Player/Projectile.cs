using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private IEnumerator Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
        yield return new WaitForSeconds(distance / speed);
        Destroy(gameObject);
    }

}