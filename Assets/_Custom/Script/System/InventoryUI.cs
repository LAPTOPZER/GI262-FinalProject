using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text itemText;
    [SerializeField] private ItemType itemType;

    void Awake()
    {
        if (itemText == null)
            itemText = GetComponent<TMP_Text>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (itemText == null) return;
        if (Inventory.Instance == null) return;

        int count = 0;
        switch (itemType)
        {
            case ItemType.KeyLV1: count = Inventory.Instance.keyLv1Count; break;
            case ItemType.KeyLV2: count = Inventory.Instance.keyLv2Count; break;
            case ItemType.KeyLV3: count = Inventory.Instance.keyLv3Count; break;
            case ItemType.KeyLV4: count = Inventory.Instance.keyLv4Count; break;
            case ItemType.KeyLV5: count = Inventory.Instance.keyLv5Count; break;
            case ItemType.HealPotion: count = Inventory.Instance.healPotion; break;
        }

        itemText.text = $"x {count}";
    }
}
