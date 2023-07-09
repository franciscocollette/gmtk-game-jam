using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; set; }

    [field: SerializeField] public Vector3 MoveDir { get; set; }
    [field: SerializeField] public Vector3 AimDir { get; set; }

    private Rigidbody rb;

    [SerializeField] private Transform aimRoot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = MoveDir * Speed;
        if(AimDir!= Vector3.zero)
            aimRoot.rotation = Quaternion.FromToRotation(Vector3.right, AimDir);
    }
}

