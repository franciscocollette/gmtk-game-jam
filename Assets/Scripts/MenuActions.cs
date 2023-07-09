using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void UI_Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void Close(GameObject target)
    {
        target.SetActive(false);
    }

    public void UI_Exit()
    {
        Application.Quit();
    }
    public void Open(GameObject target)
    {
        target.SetActive(true);
    }
}
