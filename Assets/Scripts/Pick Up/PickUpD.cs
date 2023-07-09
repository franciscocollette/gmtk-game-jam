using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float startingSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;

    private float currentVel;

    private void Awake()
    {
        currentVel = startingSpeed;
    }

    public void Magnetize(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
            return;

        var direction = target.position - transform.position;
        direction.Normalize();

        currentVel += acceleration * Time.deltaTime;
        currentVel = Mathf.Min(currentVel, maxSpeed);
        transform.position += currentVel * Time.deltaTime * direction;

        if (Vector3.Distance(target.position, transform.position) < 0.5f)
        {
            // Pick Up
            OnPickUp();
            Destroy(gameObject);
        }
    }
    protected abstract void OnPickUp();
}
