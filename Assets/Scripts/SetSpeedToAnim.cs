using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpeedToAnim : MonoBehaviour
{

    [SerializeField] private string field;

    private Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat(field, rb.velocity.magnitude);
    }
}
