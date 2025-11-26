using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    //_MainMenu
    public void StartGame()
    {
        SceneManager.LoadScene("_LoadGame");
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

    //_LoadGame
    public void NewGame()
    {
        SaveSystem.Delete();

        if (Inventory.Instance != null)
        {
            Destroy(Inventory.Instance.gameObject);
        }
        SceneManager.LoadScene("LV1");
    }

    public void LoadGame()
    {
        if (SaveSystem.TryLoad(out var data))
            SceneManager.LoadScene(data.sceneName);
        else
            Debug.LogWarning("No Save");
            return;
    }
}
