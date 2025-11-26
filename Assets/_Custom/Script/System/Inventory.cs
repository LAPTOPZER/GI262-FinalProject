using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public int keyLv1Count = 0;
    public int keyLv2Count = 0;
    public int keyLv3Count = 0;
    public int keyLv4Count = 0;
    public int keyLv5Count = 0;
    public int healPotion = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    public void Collect(ItemType type, int amount)
    {
        switch (type)
        {
            case ItemType.KeyLV1:
                keyLv1Count += amount;
                break;
            case ItemType.KeyLV2:
                keyLv2Count += amount;
                break;
            case ItemType.KeyLV3:
                keyLv3Count += amount;
                break;
            case ItemType.KeyLV4:
                keyLv4Count += amount;
                break;
            case ItemType.KeyLV5:
                keyLv5Count += amount;
                break;

            case ItemType.HealPotion:
                healPotion += amount;
                break;
        }

        RefreshUI();
    }

    public void UseHeal(int healAmount)
    {
        if (healPotion <= 0)
        {
            Debug.Log("No Item Heal");
            return;
        }

        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogWarning("ไม่พบ Player ในฉาก");
            return;
        }

        var player = playerObj.GetComponent<PlayerController>();
        if (player == null)
        {
            Debug.LogWarning("Player ไม่มี PlayerController");
            return;
        }

        healPotion -= 1;
        player.Heal(healAmount);

        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (var ui in FindObjectsOfType<InventoryUI>())
        {
            ui.UpdateUI();
        }
    }
}
