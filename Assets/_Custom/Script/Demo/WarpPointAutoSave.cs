using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPointAutoSave : MonoBehaviour
{
    [SerializeField] string targetScene;
    [SerializeField] string targetSpawnName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Vector3 currentPos = other.transform.position;

        var data = new SaveData
        {
            sceneName = targetScene,
            spawnPoint = targetSpawnName,
            playerPos = currentPos
        };

        SaveSystem.Save(data);
        SceneManager.LoadScene(targetScene);
    }
}
