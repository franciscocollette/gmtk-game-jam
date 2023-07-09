using UnityEngine;

public class StatEnableGO : MonoBehaviour
{

    [SerializeField] private GameObject target;

    [SerializeField] private Stat stat;

    private void OnEnable()
    {
        target.SetActive(GlobalStats.Instance.IsEnable(stat));
    }
    private void OnDisable()
    {
        target.SetActive(false);
    }
}