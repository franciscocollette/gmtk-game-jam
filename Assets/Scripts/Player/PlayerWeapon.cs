using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private int mouseInput;

    [SerializeField] private float attackCooldown = .6f;
    [SerializeField] private Stat attackType;

    [SerializeField] private GameObject[] attacks;

    [SerializeField] private Transform ainRoot;

    [SerializeField] private Stat attackSpeed;

    [SerializeField] private Transform parent;
    [Space]

    [SerializeField] private Animator animator;
    [SerializeField] private string trigger;

    [SerializeField] private float attackDelay;



    private bool inCooldown;

    private void OnEnable()
    {
        inCooldown = false;
    }

    void Update()
    {
        if(Input.GetMouseButton(mouseInput) && !inCooldown)
        {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        inCooldown = true;
        animator.SetTrigger(trigger);

        var bonus = GlobalStats.Instance.GetValueNormalized(attackSpeed);
        yield return new WaitForSeconds(attackDelay / bonus);

        var attackIndex = Mathf.RoundToInt(GlobalStats.Instance.GetValue(attackType));
        Instantiate(attacks[attackIndex], ainRoot.position, ainRoot.rotation, parent);
        yield return new WaitForSeconds(attackCooldown / bonus);
        inCooldown = false;
    }
}
