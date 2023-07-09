using UnityEngine;

public class RandomScaleTransform : MonoBehaviour
{

    [SerializeField] private float min = 1;
    [SerializeField] private float max = 1;
    private void Start()
    {
        transform.localScale = Vector3.one * Random.Range(min, max);
    }

}
