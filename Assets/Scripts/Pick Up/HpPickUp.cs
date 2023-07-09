using UnityEngine;

public class HpPickUp : PickUp
{

    [SerializeField] private int healAmount;

    protected override void OnPickUp()
    {
        Player.Instance.GetComponent<HitPoints>().Heal(healAmount);
    }
}
