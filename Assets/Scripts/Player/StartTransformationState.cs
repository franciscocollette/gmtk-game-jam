using UnityEngine;

public class StartTransformationState : MonoBehaviour
{

    [SerializeField] private GameObject nextState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FiniteStateMachine.SwitchState(nextState);
        }
    }
}