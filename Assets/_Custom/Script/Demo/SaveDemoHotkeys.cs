using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDemoHotkeys : MonoBehaviour
{
    [SerializeField] string defaultScene = "Game";

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (SaveSystem.TryLoad(out var data))
                SceneManager.LoadScene(data.sceneName);
            else
                SceneManager.LoadScene(defaultScene);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SaveSystem.Delete();
        }
    }
}
