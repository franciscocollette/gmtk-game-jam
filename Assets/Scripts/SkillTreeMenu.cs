using UnityEngine;

public class SkillTreeMenu : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    [SerializeField] private KeyCode key = KeyCode.T;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
