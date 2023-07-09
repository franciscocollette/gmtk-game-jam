using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    private GameObject current;

    private void Start()
    {
        current = transform.GetChild(0).gameObject;
    }
    public void State(GameObject nextState)
    {
        current.SetActive(false);
        current = nextState;
        current.SetActive(true);
    }
    public static void SwitchState(GameObject nextState)
    {
        nextState.GetComponentInParent<FiniteStateMachine>().State(nextState);
    }
}