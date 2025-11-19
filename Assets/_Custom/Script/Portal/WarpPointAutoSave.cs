using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPointAutoSave : MonoBehaviour
{
    [SerializeField] string targetScene;
    [SerializeField] string targetSpawnName;

    [SerializeField] ItemType requiredKey = ItemType.None;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player == null) return;

        if (!HasRequiredKey())
        {
            Debug.Log("No key. Can't Warp");
            return;
        }

        if (!other.CompareTag("Player")) return;

            Vector2 currentPos = other.transform.position;

            var data = new SaveData
            {
                currentHp = player.hp,
                sceneName = targetScene,
                spawnPoint = targetSpawnName,
            };

            SaveSystem.Save(data);
            SceneManager.LoadScene(targetScene);
    }

    private bool HasRequiredKey()
    {
        Inventory inv = Inventory.Instance;

        if (inv == null)
        {
            Debug.LogWarning("No Inventory this scene");
            return false;
        }

        switch (requiredKey)
        {
            case ItemType.None:
                return true;

            case ItemType.KeyLV1:
                if (inv.keyLv1Count > 0)
                {
                    inv.keyLv1Count -= inv.keyLv1Count;
                    Debug.Log("Delete KeyLV1");
                    return true;
                }
             return false;

            case ItemType.KeyLV2:
                if (inv.keyLv2Count > 0)
                {
                    inv.keyLv2Count -= inv.keyLv2Count;
                    Debug.Log("Delete KeyLV2");
                    return true;
                }
                return false;

            case ItemType.KeyLV3:
                if (inv.keyLv3Count > 0)
                {
                    inv.keyLv3Count -= inv.keyLv3Count;
                    Debug.Log("Delete KeyLV3");
                    return true;
                }
                return false;
        }
        return false;
    }
}
