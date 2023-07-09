using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private float lastScale = 1;

    private void OnEnable()
    {
        lastScale = Time.timeScale;
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = lastScale;
    }
}

