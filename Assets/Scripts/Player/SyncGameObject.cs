using UnityEngine;

public class SyncGameObject : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject[] targets;

    [SerializeField] private bool turnOn = true;

    private void OnEnable()
    {
        target.SetActive(turnOn);
        foreach (var item in targets)
        {
            item.SetActive(turnOn);
        }
    }
    private void OnDisable()
    {
        target.SetActive(!turnOn);
        foreach (var item in targets)
        {
            item.SetActive(!turnOn);
        }
    }

}
