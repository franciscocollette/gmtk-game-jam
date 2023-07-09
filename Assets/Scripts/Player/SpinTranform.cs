using UnityEngine;

public class SpinTranform : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Stat bonus;
    [SerializeField] private float speed;

    private void Update()
    {
        var speedB = GlobalStats.Instance.GetValueNormalized(bonus);
        transform.Rotate(0, speed * speedB * Time.deltaTime, 0);
    }
}
