using UnityEngine;
using UnityEngine.UI;

public class TransformationState : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] private float duration;

    [SerializeField] private GameObject nextState;

    [SerializeField] private Stat cooldown;


    private float remainingTime;
    private void OnEnable()
    {
        remainingTime = duration;
    }

    private void Update()
    {
        remainingTime -= GlobalStats.Instance.GetValueNormalized(cooldown) * Time.deltaTime;


        fillBar.fillAmount = remainingTime / duration;

        if(remainingTime <= 0)
        {
            FiniteStateMachine.SwitchState(nextState);
        }
    }

}