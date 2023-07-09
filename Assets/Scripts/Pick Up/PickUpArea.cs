using System.Collections;
using UnityEngine;

public class PickUpArea : MonoBehaviour
{
    [SerializeField] private float basePickUpRadius;

    [SerializeField] private float magnetRadius;


    private SphereCollider spherCollider;

    private void Awake()
    {
        spherCollider = GetComponent<SphereCollider>();
    }

    private void FixedUpdate()
    {
        spherCollider.radius = basePickUpRadius;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickUp>(out var pickUp))
            pickUp.Magnetize(transform);
    }

    public void TriggerManget()
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            transform.localScale = Vector3.one * magnetRadius;
            yield return new WaitForFixedUpdate();
            transform.localScale = Vector3.one;
        }
    }
}
