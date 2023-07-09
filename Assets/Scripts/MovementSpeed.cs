using UnityEngine;

public class MovementSpeed : MonoBehaviour
{

    [SerializeField] private float speed;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        playerController.Speed = speed;

    }
}

