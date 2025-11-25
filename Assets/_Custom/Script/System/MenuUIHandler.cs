using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        if (Inventory.Instance != null)
        {
            Destroy(Inventory.Instance.gameObject);
        }
        SceneManager.LoadScene("LV1");
    }
    public void Credit()
    {
        SceneManager.LoadScene("_Credit");
    }

    public void BacktoMainMenu()
    {
        if (Inventory.Instance != null)
        {
            Destroy(Inventory.Instance.gameObject);
        }

        SceneManager.LoadScene("_MainMenu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("_HowToPlay");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
