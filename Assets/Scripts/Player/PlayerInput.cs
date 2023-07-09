using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    Plane plane = new(Vector3.up, 0);
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(horizontal, 0, vertical);

        controller.MoveDir = direction.normalized;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPosition = plane.Raycast(ray, out float distance) ? ray.GetPoint(distance) : transform.position;

        var aimDir = worldPosition - transform.position;

        controller.AimDir = aimDir.normalized;
    }

}
