using UnityEngine;

public class SceneBootstrap : MonoBehaviour
{
    void Start()
    {
        if (!SaveSystem.TryLoad(out var data)) return;

        var current = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (data.sceneName != current) return;

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) { Debug.LogWarning("No Player found in scene."); return; }

        //หา spawn point ตามชื่อก่อน
        if (!string.IsNullOrEmpty(data.spawnPoint))
        {
            var spawn = GameObject.Find(data.spawnPoint);
            if (spawn != null)
            {
                player.transform.position = spawn.transform.position;
            }
        }

        var playerCtrl = player.GetComponent<PlayerController>();
        if (playerCtrl != null)
        {
            playerCtrl.SetHp(data.currentHp);
            return;
        }
    }
}
