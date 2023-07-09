using UnityEngine;

public class ChasePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        var playerPos = Player.Instance.transform.position;
        var dir = playerPos - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;
    }
}