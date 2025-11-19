using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public int keyLv1Count = 0;
    public int keyLv2Count = 0;
    public int keyLv3Count = 0;

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
        }
    }
}
