using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPointAutoSave : MonoBehaviour
{
    [SerializeField] string targetScene;
    [SerializeField] string targetSpawnName;

    [SerializeField] ItemType requiredKey = ItemType.None;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject warpText;
    [SerializeField] GameObject noKeyText;

    private bool playerInRange = false;
    private PlayerController currentPlayer;

    private void Update()
    {
        if (!playerInRange) return;
        if (!Input.GetKeyDown(KeyCode.F)) return;

        if (!UseRequiredKey())
        {
            noKeyText.SetActive(true);
            warpText.SetActive(false);
        }

        var data = new SaveData
        {
            currentHp = currentPlayer.hp,
            sceneName = targetScene,
            spawnPoint = targetSpawnName,
        };

        SaveSystem.Save(data);
        SceneManager.LoadScene(targetScene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        currentPlayer = other.GetComponent<PlayerController>();
        if (currentPlayer == null) return;

        playerInRange = true;

        bool hasKey = HasRequiredKey();

        if (hasKey)
        {
            if (warpText != null) warpText.SetActive(true);
            if (noKeyText != null) noKeyText.SetActive(false);
        }
        else
        {
            if (warpText != null) warpText.SetActive(false);
            if (noKeyText != null) noKeyText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        playerInRange = false;
        currentPlayer = null;

        if (warpText != null) warpText.SetActive(false);
        if (noKeyText != null) noKeyText.SetActive(false);
    }

    private bool HasRequiredKey()
    {
        Inventory inv = Inventory.Instance;

        if (inv == null)
        {
            Debug.LogWarning("No Inventory in this scene");
            return false;
        }

        switch (requiredKey)
        {
            case ItemType.None:
                return true;
            case ItemType.KeyLV1: return inv.keyLv1Count > 0;
            case ItemType.KeyLV2: return inv.keyLv2Count > 0;
            case ItemType.KeyLV3: return inv.keyLv3Count > 0;
            case ItemType.KeyLV4: return inv.keyLv4Count > 0;
            case ItemType.KeyLV5: return inv.keyLv5Count > 0;
        }
        return false;
    }

    private bool UseRequiredKey()
    {
        Inventory inv = Inventory.Instance;
        if (inv == null) return false;

        switch (requiredKey)
        {
            case ItemType.None:
                return true;

            case ItemType.KeyLV1:
                if (inv.keyLv1Count > 0)
                {
                    inv.keyLv1Count -= 1;
                    return true;
                }
                return false;

            case ItemType.KeyLV2:
                if (inv.keyLv2Count > 0)
                {
                    inv.keyLv2Count -= 1;
                    return true;
                }
                return false;

            case ItemType.KeyLV3:
                if (inv.keyLv3Count > 0)
                {
                    inv.keyLv3Count -= 1;
                    return true;
                }
                return false;

            case ItemType.KeyLV4:
                if (inv.keyLv4Count > 0)
                {
                    inv.keyLv4Count -= 1;
                    return true;
                }
                return false;

            case ItemType.KeyLV5:
                if (inv.keyLv5Count > 0)
                {
                    inv.keyLv5Count -= 1;
                    if (winText != null) winText.SetActive(true);
                    Time.timeScale = 0;
                    return true;
                }
                return false;
        }

        return false;
    }
}
